using System;

namespace CodingDojo4_Damil.ViewModel
{
    public class Client
    {
        private string v1;
        private int v2;
        private Action<string> action;
        private object clientDissconnected;
        private Action clientDisconnected;

        public Client(string v1, int v2, Action<string> action, object clientDissconnected)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.action = action;
            this.clientDissconnected = clientDissconnected;
        }

        public Client(string v1, int v2, Action<string> action, Action clientDisconnected)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.action = action;
            this.clientDisconnected = clientDisconnected;
        }

        internal void Send(string v)
        {
            throw new NotImplementedException();
        }
    }
}