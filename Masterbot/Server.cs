using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterbot {
    public class Server : WrapDiscord<Discord.Server> {
        public string Name => Inner.Name;
        public string Region => Inner.Region;
        public bool IsOwner => Inner.IsOwner;
        public User Owner => new User(Client, Inner.Owner);
        public User CurrentUser => new User(Client, Inner.CurrentUser);
        public DateTime JoinedAt => Inner.JoinedAt;

        public IEnumerable<User> Members => Inner.Members.Select(m => new User(Client, m));
        public IEnumerable<long> Bans => Inner.Bans; 

        public IEnumerable<Channel> Channels => Inner.Channels.Select(c => new Channel(Client, c));
        public IEnumerable<Channel> TextChannels => Inner.TextChannels.Select(c => new Channel(Client, c));
        public IEnumerable<Channel> VoiceChannels => Inner.VoiceChannels.Select(c => new Channel(Client, c));
        public Channel DefaultChannel => new Channel(Client, Inner.DefaultChannel);

        public Channel AfkChannel => new Channel(Client, Inner.AFKChannel);
        public TimeSpan AfkTimeout => TimeSpan.FromSeconds(Inner.AFKTimeout);

        public IEnumerable<Role> Roles => Inner.Roles.Select(r => new Role(Client, r));
        public Role EveryoneRole => new Role(Client, Inner.EveryoneRole);

        public Server(ChatClient client, Discord.Server inner): base(client, inner) {}
    }
}