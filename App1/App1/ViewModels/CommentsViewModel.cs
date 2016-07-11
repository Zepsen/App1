using App1.Models.HelperModel;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class CommentsViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private AddCommentsModel _comment = new AddCommentsModel();
        private string _trailId;

        public CommentsViewModel(string id)
        {
            
            _comment.Id = id;
        }

        public const string NamePropertyName = "Name";
        public string Name
        {
            get
            {
                return _comment.Name;
            }
            set
            {
                _comment.Name = value;
                OnPropertyChanged(nameof(_comment.Name));
            }
        }

        public const string RatePropertyName = "Rate";
        public double Rate
        {
            get
            {
                return _comment.Rate;
            }
            set
            {
                _comment.Rate = value;
                OnPropertyChanged(nameof(_comment.Rate));
            }
        }

        public const string CommentPropertyName = "Comment";
        public string Comment
        {
            get
            {
                return _comment.Comment;
            }
            set
            {
                _comment.Comment = value;
                OnPropertyChanged(nameof(_comment.Comment));
            }
        }

        private Command commentCommand;
        public const string CommentCommandPropertyName = "CommentCommand";
        public Command CommentCommand
        {
            get
            {
                return commentCommand ?? (commentCommand = new Command(async () => await ExecuteCommentCommand()));
            }
        }

        private async Task ExecuteCommentCommand()
        {
            if (DbQueryAsync.AddComment(_comment))
            {
                _comment.Name = string.Empty;
                _comment.Rate = 0;
                _comment.Comment = string.Empty;                
            };            
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }

    
}
