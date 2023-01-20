namespace Namespace {
    
    using socket;
    
    using select;
    
    using sys;
    
    using System.Collections.Generic;
    
    public static class Module {
        
        public static object ServerIP = "127.0.0.1";
        
        public static object ServerPORT = 1234;
        
        public static object Space = "<SPACE>";
        
        public static object List_Of_Clients = new List<object>();
        
        public static object server = socket.socket(socket.AF_INET, socket.SOCK_STREAM);
        
        static Module() {
            server.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1);
            server.bind((ServerIP, ServerPORT));
            server.listen(5);
            List_Of_Clients.append(client_socket);
            start_new_thread(listen_for_client, ValueTuple.Create(client_socket));
            cs.close();
            server.close();
        }
        
        // make the port as reusable port
        // bind the socket to the address we specified
        // listen for upcoming connections
        //This function keep listening for a message from `Client Socket` socket
        //Whenever a message is received, broadcast it to all other connected clients
        public static object listen_for_client(object cs) {
            while (true) {
                try {
                    // keep listening for a message from `cs` socket
                    var msg = cs.recv(2048).decode("utf-8");
                } catch (Exception) {
                    // client no longer connected
                    // remove it from the set
                    Console.WriteLine("[!] Error: {e}");
                    List_Of_Clients.remove(cs);
                }
                foreach (var client_socket in List_Of_Clients) {
                    // and send the message
                    client_socket.send(msg.encode("utf-8"));
                }
            }
        }
    }
}
