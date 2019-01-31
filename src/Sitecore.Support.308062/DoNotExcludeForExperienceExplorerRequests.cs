using Sitecore.Analytics.Pipelines.ExcludeRobots;

namespace Sitecore.Support
{
  public class DoNotExcludeForExperienceExplorerRequests : ExcludeRobotsProcessor
  {
    public override void Process(ExcludeRobotsArgs args)
    {
      var mode = Context.Items["SC_ExperienceExplorer_Mode"] as bool?;
      bool urlContainsExplorer = false;
      if (Context.Request != null && Context.Request.FilePath != null)
      {
        urlContainsExplorer = Context.Request.FilePath.Contains("sitecore modules/web/experienceexplorer/") ||
                              Context.Request.FilePath.Contains("sitecore/api/ssc/experienceexplorer/");
      }

      if (urlContainsExplorer || (mode.HasValue && mode.Value))
      {
        args.IsInExcludeList = false;
        args.AbortPipeline();
      }
    }
  }
}