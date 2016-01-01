using System;
using System.Collections.Generic;
using Discord;

namespace Masterbot {
    /// <summary>
    /// Implements equality for Discord.NET wrapper types.
    /// </summary>
    /// <typeparam name="TInner">The underlying Discord.NET type.</typeparam>
    public abstract class WrapDiscord<TInner>: IEquatable<WrapDiscord<TInner>> where TInner: CachedObject<long> {

        public ChatClient Client { get; }
        public long Id => Inner.Id;
        internal TInner Inner { get; }

        protected WrapDiscord(ChatClient client, TInner inner) {
            Client = client;
            Inner = inner;
        }

        public bool InnerEquals(TInner other) {
            return Equals(Inner, other);
        }

        public bool Equals(WrapDiscord<TInner> other) {
            if (ReferenceEquals(null, other)) {
                return false;
            }
            return ReferenceEquals(this, other)
                || EqualityComparer<TInner>.Default.Equals(Inner, other.Inner);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            if (ReferenceEquals(this, obj)) {
                return true;
            }
            var other = obj as WrapDiscord<TInner>;
            return other != null && Equals(other);
        }

        public override int GetHashCode() {
            return EqualityComparer<TInner>.Default.GetHashCode(Inner);
        }

        public static bool operator ==(WrapDiscord<TInner> left, WrapDiscord<TInner> right) {
            return Equals(left, right);
        }

        public static bool operator !=(WrapDiscord<TInner> left, WrapDiscord<TInner> right) {
            return !Equals(left, right);
        }
    }
}
