namespace Clio.ProjectManagerModel.ViewModel.Content
{
    public sealed class TaskContent : PresentationContent
    {
        public TaskContent(IPMViewModel viewModel) : base(viewModel)
        {
            ContentType = ContentType.Task;
        }
    }
}
