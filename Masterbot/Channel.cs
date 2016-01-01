using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterbot {
    public class Channel: WrapDiscord<Discord.Channel> {
        public string Name => Inner.Name;
        public string Topic => Inner.Topic;
        public int Position => Inner.Position;
        public bool IsPrivate => Inner.IsPrivate;
        public Server Server => new Server(Client, Inner.Server);
        public User Recipient => new User(Client, Inner.Recipient);

        public IEnumerable<PermissionOverwrite> PermissionOverwrites
            => Inner.PermissionOverwrites.Select(p => new PermissionOverwrite(p));

        public ChannelType Type { get {
            ChannelType val;
            return Enum.TryParse(Inner.Type, false, out val)
                ? val : ChannelType.Unknown;
        } }

        public IEnumerable<User> Members => Server.Members;

        public IEnumerable<Message> Messages => Inner.Messages.Select(m => new Message(Client, m));

        public Channel(ChatClient client, Discord.Channel inner): base(client, inner) {
        }
    }

    public enum ChannelType {
        Text,
        Voice,
        Unknown
    }
}
