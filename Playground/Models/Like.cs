using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Playground.Models
{
    public sealed class Like : Base, ILike
    {
        private int _likeCount;
        private bool? _isLiked;

        public int LikeCount
        {
            get => _likeCount;
            set
            {
                _likeCount = value;
                OnPropertyChanged();
            }
        }

        public bool? IsLiked
        {
            get => _isLiked;
            set
            {
                _isLiked = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}