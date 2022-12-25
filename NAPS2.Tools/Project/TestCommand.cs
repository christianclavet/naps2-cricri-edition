namespace NAPS2.Tools.Project;

public class TestCommand : ICommand<TestOptions>
{
    public int Run(TestOptions opts)
    {
        // TODO: Framework options (e.g. "-f net462")
        var depsRootPath = OperatingSystem.IsMacOS()
            ? "NAPS2.App.Mac/bin/Debug/net7-macos10.15"
            : OperatingSystem.IsLinux()
                ? "NAPS2.App.Gtk/bin/Debug/net6"
                : "NAPS2.App.WinForms/bin/Debug/net462";
        Output.Info("Running tests");
        Cli.Run("dotnet", "test", new()
        {
            { "NAPS2_TEST_DEPS", Path.Combine(Paths.SolutionRoot, depsRootPath) }
        });
        Output.Info("Tests passed.");
        return 0;
    }
}