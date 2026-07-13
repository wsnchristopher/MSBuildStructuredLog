namespace Microsoft.Build.Logging.StructuredLogger
{
    /// <summary>
    /// Needed for Avalonia so it can uniformly bind to TreeNode.IsExpanded and NameValueNode.IsExpanded
    /// </summary>
    public interface IExpandable
    {
        bool IsExpanded { get; set; }
        bool IsVisible { get; set; }
    }
}