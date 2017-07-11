using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Playground.Models
{
    public sealed class Follow : Base, IFollow
    {
        private int _followCount;
        private bool? _isFollowed;

        public int FollowCount
        {
            get => _followCount;
            set
            {
                _followCount = value;
                OnPropertyChanged();
            }
        }

        public bool? IsFollowed
        {
            get => _isFollowed;
            set
            {
                _isFollowed = value;
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