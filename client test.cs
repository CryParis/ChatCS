namespace Namespace {
    
    using socket;
    
    using random;
    
    using sys;
    
    using select;
    
    using datetime = datetime.datetime;
    
    using Fore = colorama.Fore;
    
    using init = colorama.init;
    
    using Back = colorama.Back;
    
    using System.Collections.Generic;
    
    public static class Module {
        
        static Module() {
            init();
            socks.connect((ServerIP, ServerPORT));
            socks.shutdown();
            socks.send(message_send.encode("utf-8"));
            socks.close();
        }
        
        public static object colors = new List<object> {
            Fore.BLUE,
            Fore.CYAN,
            Fore.GREEN,
            Fore.RED,
            Fore.YELLOW
        };
        
        public static object client_color = random.choice(colors);
        
        public static object ServerIP = "127.0.0.1";
        
        public static object ServerPORT = 1234;
        
        public static object SPACE = "<SPACE>";
        
        public static object name = input("Enter your name: ");
        
        public static object socks = socket.socket();
        
        public static object sockets_list = new List<object> {
            sys.stdin,
            socks
        };
        
        public static object message = each_sock.recv(2048).decode("utf-8");
        
        public static object message_send = input();
        
        public static object date_now = datetime.now().strftime("%H:%M:%S");
        
        public static object message_send = "{client_color}[{date_now}] {name}{SPACE}{message_send}{Fore.RESET}";
    }
}
