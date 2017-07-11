using System.ComponentModel;

namespace Playground.Models
{
    public interface ILike : INotifyPropertyChanged
    {
        int LikeCount { get; set; }
        bool? IsLiked { get; set; }
    }
}