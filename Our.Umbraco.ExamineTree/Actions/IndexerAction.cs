using umbraco.interfaces;

namespace Our.Umbraco.ExamineTree.Actions
{

    public class IndexerAction : IAction
    {

        public char Letter
        {
            get { return default(char); }
        }

        public bool ShowInNotifier
        {
            get { return false; }
        }

        public bool CanBePermissionAssigned
        {
            get { return false; }
        }

        public string Icon
        {
            get { return "sync"; }
        }

        public string Alias
        {
            get { return "rebuild"; }
        }

        public string JsFunctionName
        {
            get { return ""; }
        }

        public string JsSource
        {
            get { return ""; }
        }

    }

}