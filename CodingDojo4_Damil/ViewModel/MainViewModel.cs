using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CodingDojo4_Damil.ViewModel
{
    
    public class MainViewModel : ViewModelBase
    {
        public Client client;
        public bool isConnected = false;

        
        public string Chatname { get; set; }
        public RelayCommand ConnectBtnClick { get; set; }
        public ObservableCollection<string> ReceivedMsgs { get; set; }        
        public string Msg { get; set; }
        public RelayCommand SendBtnClick { get; set; }




        public MainViewModel()
        {
            ConnectBtnClick = new RelayCommand(
                () => 
                    {
                        isConnected = true;
                        client = new Client("127.0.0.1", 10100, new Action<string>(NewMsgReceived), ClientDisconnected);
                    }, 
                () => 
                    { return (isConnected = false); ; }
            );

            ReceivedMsgs = new ObservableCollection<string>();
            Msg = "";

            SendBtnClick = new RelayCommand(
                () => 
                    {
                        client.Send(Chatname + ": " + Msg);
                        ReceivedMsgs.Add("YOU: " + Msg);
                    }, 
                () => 
                    { return (isConnected && Msg.Length >= 1); }
            );

        }

        private void NewMsgReceived(string msg)
        {
            App.Current.Dispatcher.Invoke(() => { ReceivedMsgs.Add(msg); });
        }
        private void ClientDisconnected()
        {           
            isConnected = false;
            //to force the update of the button visibility!!!!
            CommandManager.InvalidateRequerySuggested();
        }



    }
}