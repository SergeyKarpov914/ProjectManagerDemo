namespace Clio.ProjectManagerModel.ViewModel.Content
{
    public sealed class TaskContent : PresentationContent
    {
        public TaskContent(IPresentationContent viewModel) : base(viewModel)
        {
            ContentType = ContentType.Task;
        }
    }
}
