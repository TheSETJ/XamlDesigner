using System;

namespace Playground.Models
{
    public class Unified
    {
        private readonly Type _type;

        public Unified(Follow item)
        {
            _type = item.GetType();
            Base = item;
            FollowInfo = item;
        }

        public Unified(Like item)
        {
            _type = item.GetType();
            Base = item;
            LikeInfo = item;
        }

        public Base Base { get; }
        public IFollow FollowInfo { get; }
        public ILike LikeInfo { get; }

        public Type GetItemType()
        {
            return _type;
        }
    }
}