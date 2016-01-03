using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterbot {
    public class User : WrapDiscord<Discord.User> {
        public string Name => Inner.Name;
        public short Discriminator => Inner.Discriminator;
        public Server Server => new Server(Client, Inner.Server);
        public string AvatarId => Inner.AvatarId;
        public Uri AvatarUrl => new Uri(Inner.AvatarUrl);
        public string GameId => Inner.GameId;

        public bool IsPrivate => Inner.IsPrivate;
        public bool IsServerDeafened => Inner.IsServerDeafened;
        public bool IsSelfDeafened => Inner.IsSelfDeafened;
        public bool IsServerMuted => Inner.IsServerMuted;
        public bool IsSelfMuted => Inner.IsSelfMuted;
        public bool IsServerSupressed => Inner.IsServerSuppressed;

        public bool IsSpeaking => Inner.IsSpeaking;
        public DateTime JoinedAt => Inner.JoinedAt;
        public DateTime? LastActivityAt => Inner.LastActivityAt;
        public DateTime? LastOnlineAt => Inner.LastOnlineAt;

        public IEnumerable<Channel> Channels => Inner.Channels.Select(c => new Channel(Client, c));
        public IEnumerable<Message> Messages => Inner.Messages.Select(m => new Message(Client, m));
        public Channel PrivateChannel => new Channel(Client, Inner.PrivateChannel);
        public Channel VoiceChannel => new Channel(Client, Inner.VoiceChannel);
        public IEnumerable<Role> Roles => Inner.Roles.Select(r => new Role(Client, r));

        public string SessionId => Inner.SessionId;
        public string Token => Inner.Token;
        public UserStatus Status => Inner.Status.Into();

        public User(ChatClient client, Discord.User inner): base(client, inner) {}

        public ChannelPermissions GetPermissions(Channel channel) => Inner.GetPermissions(channel.Inner);
    }
}