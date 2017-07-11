using System.ComponentModel;

namespace Playground.Models
{
    public interface IFollow : INotifyPropertyChanged
    {
        int FollowCount { get; set; }
        bool? IsFollowed { get; set; }
    }
}