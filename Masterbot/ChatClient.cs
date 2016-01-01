using System.Collections.Generic;
using System.Linq;
using Discord;

namespace Masterbot {
    public class ChatClient {
        public IEnumerable<Server> Servers => _discord.AllServers
                                                      .Select(s => new Server(this, s));

        public IEnumerable<Channel> Channels => _discord.AllServers
                                                        .SelectMany(s => s.Channels)
                                                        .Concat(_discord.PrivateChannels)
                                                        .Select(c => new Channel(this, c));

        public IEnumerable<User> Users => _discord.AllServers
                                                  .SelectMany(s => s.Members)
                                                  .Select(u => new User(this, u));

        private readonly DiscordClient _discord;

        internal ChatClient() {
            _discord = new DiscordClient();
        }
    }
}
