using CSharpFunctionalExtensions;
using Nuke.Common;
using Nuke.Common.Git;
using Nuke.Common.ProjectModel;
using Nuke.Common.Tools.DotNet;
using Nuke.Common.Tools.GitVersion;
using Zafiro.Deployment;
using Zafiro.Misc;
using static Nuke.Common.Tools.DotNet.DotNetTasks;

class Build : NukeBuild
{
    [Parameter] readonly bool Force;
    [Parameter("GitHub Authentication Token")] [Secret] readonly string GitHubApiKey;
    [GitVersion] readonly GitVersion GitVersion;
    [GitRepository] readonly GitRepository Repository;
    [Solution] readonly Solution Solution;

    Target RestoreWorkloads => td => td
        .Executes(() =>
        {
            DotNetWorkloadRestore(x => x.SetProject(Solution));
        });

    Target PublishSite => d => d
        .Requires(() => GitHubApiKey)
        .DependsOn(RestoreWorkloads)
        .OnlyWhenStatic(() => Repository.IsOnMainOrMasterBranch() || Force)
        .Executes(async () =>
        {
            await Solution.AllProjects.TryFirst(project => project.Name.EndsWith(".Browser"))
                .ToResult("Browser project not found")
                .Map(project => project.Path.ToString())
                .Bind(projectPath => Deployer.Instance.PublishAvaloniaAppToGitHubPages(projectPath, "SuperJMN", "Site", GitHubApiKey))
                .TapError(error => Assert.Fail(error.ToString()))
                .LogInfo("Site published");
        });

    Target Publish => td => td
        .DependsOn(PublishSite);

    public static int Main() => Execute<Build>(x => x.Publish);
}