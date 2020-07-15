using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Media;
using System.IO;
using System.Reflection;

namespace SlotMachine_1.a._2
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.Title = "JACKPOT -- C#";
            Console.SetWindowSize(74, 40);
            DireStraits.SoundLocation = AppDomain.CurrentDomain.BaseDirectory + "\\.Dire Straits - Money For Nothing.wav";
            Console.OutputEncoding = System.Text.Encoding.UTF8;
           

            MenuPrincipal();
        }

        //Default settings (caso nenhuma opcao seja seleccionada)
        private static string[] simbolos = new string[10] { "♠", "♣", "♥", "♦", "◊", "○", "●", "◌", "☼", "✶"};
        private static int dificuldade = 4; //2 para teste , 4 é default (easy)
        private static int creditos = 1000;
       
        //Sistema
        private static ConsoleKeyInfo tecla;
        private static string user = null;
        private const string path = ".\\highscore.txt";
        private const string path2 = ".\\users.txt";
        private static string[] lerScore = System.IO.File.ReadAllLines(path);
        private static string[] lerUsers = System.IO.File.ReadAllLines(path2);

        //estatística
        private static int jogosJogados = Convert.ToInt32(lerScore[0]);
        private static int jogosGanhos = Convert.ToInt32(lerScore[1]);
        private static int jogosPerdidos = Convert.ToInt32(lerScore[2]);

        //Cores
        private static ConsoleColor cor = ConsoleColor.DarkRed;

        //Lingua
        private static Lingua language = new Lingua(); // default Português;

        //Musica
        private static SoundPlayer DireStraits = new SoundPlayer();
        private static bool condition; //switch da música
        private static string symbol = "[◄ ]";

        //============================================================================================================================================================//

        static void MenuPrincipal() { //Seleccao Principal
            
            int opcao, multiplicador = 0; // multiplicador da aposta

            for( ; ; )
            {
                opcao = upDownArrow(language.principal()); //Seleccao

                switch (opcao)
                {
                    case 0: SlotMachine(simbolos, multiplicador);
                        break;
                    case 1: multiplicador = Opcoes();
                        break;
                    case 2: Traducao();
                        break;
                    case 3: Salvar();
                        break;
                    case 4: Highscore();
                        break;
                    default:SairPrograma();
                        break;
                }

            } 
        }


        static void about() {

        Console.Clear();
        if(language.getLingua() == 0) { 
          
          Console.Write(@" 
                              ABOUT
 =======================================================================
 Nome.    Filipe Miguel Rosário
 Email.   fmcancelinha@gmail.com

 Sobre.   Jogo simples que simula uma slot machine de 1 ou 3 filas com 
          opcao de 3, 4 simbolos e 9 casas;

 Versao.  1.a.4
 Modulo.  C#
 =======================================================================
 ");
        } else {
          Console.Write(@"
                               ABOUT
 =======================================================================
 Name.    Filipe Miguel Rosário
 Email.   fmcancelinha @gmail.com

 About.   Simple Console App that simulates a slot machine with 1 or 3 
          Rows with the option to have 3, 4 or 9 Slots;

 Version. 1.a.4
 Class.   C#
 =======================================================================
");
          }

         Console.ReadKey();
         Console.Clear();
        }

        static int Opcoes() { // Sub-Menu

            //MENU
            int opcoes, multiplicador = 0;
            Console.Clear();

           for(; ; ){

                opcoes = upDownArrow(language.lingua5());
                
                switch (opcoes)
                {
                    case 0: simbolos = MenuTema(simbolos); break;
                    case 1: multiplicador = MenuDificuldade(); break;
                    case 2: cor = Colors(); break;
                    case 3: MudarUtilizador(); break;
                    default: 
                         Console.Clear();
                         return multiplicador; 
                }

            } 

        }

        static void MudarUtilizador(){
        Console.Clear();

        Console.ForegroundColor = cor;
        Console.SetCursorPosition(26, 14);
        Console.WriteLine("╔═════════════════════╗");
        Console.SetCursorPosition(26, 15);
        Console.WriteLine("║                     ║");
        Console.SetCursorPosition(26, 16);
        Console.WriteLine("╚═════════════════════╝\n");
        Console.ResetColor();

        if (language.getLingua() == 0)
        {

        Console.SetCursorPosition(28, 15);
        Console.Write("Novo nome do Jogador");
        }
        else
        {

        Console.SetCursorPosition(30, 15);
        Console.Write("New Player Name");
        }

        Console.ForegroundColor = cor;
        Console.SetCursorPosition(35, 17);
        user = Console.ReadLine();
        
        Console.Clear();
        }



        static void Traducao() {

            string[] linguas = { "\n\t\t\t\t[ Português ]", "\n\t\t\t\t[ English ]"};
            Console.Clear();
            language.setLingua(upDownArrow(linguas));
            Console.Clear(); 
        }

        static void jacktopInterface() // Estética
        {
            
            Console.ForegroundColor = cor;
            Console.Write("    █");
            Console.ResetColor();
            Console.BackgroundColor = cor;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("♠       ♣         ♥        ♦        ♠        ♣        ♥       ♦ ");
            Console.ResetColor();
            Console.ForegroundColor = cor;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("║");
            Console.WriteLine("    ██╔════════════════════════════════════════════════════════════██║");
            Console.WriteLine("    ██║                                                            ██║");
            Console.WriteLine("    ██║      ██╗ █████╗  ██████╗██╗  ██╗██████╗  ██████╗ ████████╗ ██║");
            Console.WriteLine("    ██║      ██║██╔══██╗██╔════╝██║ ██╔╝██╔══██╗██╔═══██╗╚══██╔══╝ ██║");
            Console.WriteLine("             ██║███████║██║     █████╔╝ ██████╔╝██║   ██║   ██║       ");
            Console.WriteLine("        ██   ██║██╔══██║██║     ██╔═██╗ ██╔═══╝ ██║   ██║   ██║       ");
            Console.WriteLine("        ╚█████╔╝██║  ██║╚██████╗██║  ██╗██║     ╚██████╔╝   ██║       ");
            Console.WriteLine("         ╚════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝      ╚═════╝    ╚═╝       ");
            Console.Write("        ═══════════════════════════════════════════════════ ");
            Console.ResetColor();
            Console.Write("Filipe");
            Console.WriteLine("\n\t\t\t" + @" // Slot Machine [JACKPOT] \\");

            language.lingua1();

        }

        static void jacktopLower()
        {
            Console.ForegroundColor = cor;
            Console.WriteLine("\n\n");
            Console.WriteLine("    ██║                                                            ██║");
            Console.WriteLine("    ██║                                                            ██║");
            Console.WriteLine("    ██║                                                            ██║");
            Console.Write("    ██║"); 
            Console.ResetColor();
            language.lingua2();
            Console.ForegroundColor = cor; 
            Console.WriteLine("\t\t\t   ██║");
            Console.WriteLine("    █████████████████████████████████████████████████████████████████║");
            Console.WriteLine("    ╚════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void jacktopSlotMachine() {

            Console.ForegroundColor = cor;
            Console.SetCursorPosition(23, 10);
            Console.WriteLine("\r\t╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("\r\t║ ██████████████████████████████████████████████████████ ║");
            Console.WriteLine("\r\t║ ██══════════════════════════════════════════════════██ ║");
            Console.WriteLine("\r\t║ ██                                                  ██ ║");
            Console.WriteLine("\r\t║ ██                                                  ██ ║");
            Console.ResetColor();
        }

        static void jacktopSlotMachine2(){
            
            Console.ForegroundColor = cor;
            Console.SetCursorPosition(23, 15);
            Console.WriteLine("\r\t║ ██                                                  ██ ║");
            Console.WriteLine("\r\t║ ██                                                  ██ ║");
            Console.WriteLine("\r\t║ ██                                                  ██ ║");
            Console.WriteLine("\r\t║ ██══════════════════════════════════════════════════██ ║");
            Console.WriteLine("\r\t║ ██████████████████████████████████████████████████████ ║");
            Console.WriteLine("\r\t╚════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void visorAposta() {

            Console.ForegroundColor = cor;
            Console.WriteLine("\t\t    ╔════════════════════════════════╗");
            Console.WriteLine("\t\t    ║██                            ██║");
            Console.WriteLine("\t\t    ╚════════════════════════════════╝");
            Console.ResetColor();
        }

        static void visorTipoJogo() {

            Console.ForegroundColor = cor;
            Console.SetCursorPosition(20, 10);
            Console.WriteLine("╔════════════════════════════════╗");
            Console.SetCursorPosition(20, 11);
            Console.WriteLine("║                                ║");
            Console.SetCursorPosition(20, 12);
            Console.WriteLine("╚════════════════════════════════╝");
            Console.ResetColor();
        }

        static void Alavanca() {
            
            Console.ForegroundColor = cor;
            Console.SetCursorPosition(3, 13);
            Console.WriteLine("(_)");
            Console.WriteLine("    ║ ");
            Console.WriteLine("    ▓ ");
            Console.WriteLine("    █ ");
            Console.WriteLine("    █ ");
            Console.WriteLine("  ║ █ ║");
            Console.WriteLine("  ║ █ ║");
            Console.WriteLine("  ╚═══╝");

            Console.ResetColor();
  
        }

       static void AlavancaBaixa() {
            
            Console.ForegroundColor = cor;
            Console.SetCursorPosition(3, 13);
            Console.WriteLine("   ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("      ");
            Console.WriteLine("  ║   ║");
            Console.WriteLine("  ║(_)║");
            Console.WriteLine("  ╚═══╝");

            Console.ResetColor();
  
       }



       static void JacktopPontosUser(){

            language.lingua3();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(creditos);
            Console.ResetColor();
            Console.Write("]$");
            
            Console.SetCursorPosition(13, 25);
            language.username();
            Console.ForegroundColor = cor;
            Console.Write(user);
            Console.ResetColor();
            Console.Write("]");
       }

        
       static int MenuDificuldade() {  // Escolha de dificuldade -- 1 Fila

            Console.Clear();
            
            ////////MENU///////
            int opcao = upDownArrow(language.dificuldade()); //Seleccao

            switch (opcao) { // Basta mudar os numeros para modificar a dificuldade (> o numero; <% de acertar)
                case 0: dificuldade = 4;  break;
                case 1: dificuldade = 6;  break;
                case 2: dificuldade = 8;  break;
                case 3: dificuldade = 10; break;
                default:
                    break;
            }

            Console.Clear();
            return opcao;

       }

        
       static string[] MenuTema(string[] simbolos){ //Escolha do tema da Slot Machine
            Console.Clear();
            ////////MENU///////
            int opcao = upDownArrow(language.tema()); //Seleccao

            switch (opcao) {

                case 0: simbolos = new string[10] { "!", "#", "$", "%", "&", "=", "@", "~", "»", "«"};
                    break;
                case 1: simbolos = new string[10] { "α", "β", "Γ", "Δ", "ε", "ζ", "λ", "μ", "π", "Ω"};
                    break;
                case 2: simbolos = new string[10] { "❶", "❷", "❸", "❹", "❺", "❻", "❼", "❽", "❾", "❿"};
                    break;
                case 3: simbolos = new string[10] { "♠", "♣", "♥", "♦", "◊", "○", "●", "◌", "☼", "✶"};
                    break;
                case 4: simbolos = new string[10] { "₡", "₢", "₣", "₤", "₥", "₦", "₩", "₪", "€", "₭"};
                    break;
                default:
                    break;
            }
            Console.Clear();
            return simbolos; //return
        }


        static ConsoleColor Colors(){

            Console.Clear();

            int opcao = upDownArrow(language.lingua4());

            switch (opcao) {
                case 0: cor = ConsoleColor.DarkRed     ;break;
                case 1: cor = ConsoleColor.DarkBlue    ;break;
                case 2: cor = ConsoleColor.DarkCyan    ;break;
                case 3: cor = ConsoleColor.DarkGray    ;break;
                case 4: cor = ConsoleColor.DarkGreen   ;break;
                case 5: cor = ConsoleColor.DarkMagenta ;break;
                case 6: cor = ConsoleColor.DarkYellow  ;break;
                case 7: cor = ConsoleColor.White       ;break;
                default:
                    break;
            }
            Console.Clear();
            return cor;
        }

        static int upDownArrow(string[] menu) { //Metodo Seleccionador Cima - Baixo

            int onde = 0;  //Variavel localizadora
            
            do {

                Console.SetCursorPosition(0, 1);
                jacktopInterface();

                for (int m = 0; m < menu.Length; m++) { // Percorrer o Menu
                    if (onde == m){
                        Console.SetCursorPosition(33, m + 15);
                        Console.ForegroundColor = cor;        
                        Console.WriteLine(menu[m]);
                        Console.ResetColor();
                    } else {
                        Console.SetCursorPosition(33, m + 15);
                        Console.WriteLine(menu[m]);
                    }
                }

                Console.SetCursorPosition(0, 25);
                JacktopPontosUser();
                jacktopLower();
                Console.SetCursorPosition(5, 34);
                Musica();
                Console.SetCursorPosition(35, 34);
                showAboutMusic();

                tecla = Console.ReadKey(true);
               
                if (tecla.Key == ConsoleKey.DownArrow) {
                    onde++;
                    if (onde > menu.Length - 1) 
                        onde = 0; //dar a volta ao menu
                } else if (tecla.Key == ConsoleKey.UpArrow) {
                    onde--;
                    if (onde < 0) 
                        onde = Convert.ToInt16(menu.Length - 1);  // dar a volta por cima
                }

                if(tecla.Key == ConsoleKey.A || tecla.Key == ConsoleKey.S){
                        about();
                }

                //Escape
                if (tecla.Key == ConsoleKey.Escape) {
                    onde = menu.Length - 1; // Default vai sair por aqui
                    break;
                }

            } while (tecla.Key != ConsoleKey.Enter);

            return onde; // return
        }

         static int leftRigthArrow(string[] array, ConsoleColor cor, int cursor) { //Metodo Seleccionador Direita- Esquerda

            int onde = 0;  //Variavel localizadora
            
            do {
                Console.SetCursorPosition(26, cursor);
                for (int m = 0; m < array.Length; m++) { // Percorrer o Menu
                    if (onde == m){
                        Console.ForegroundColor = cor;        
                        Console.Write("["+ array[m]+"]");
                        Console.ResetColor();
                    } else {
                        Console.Write(" "+ array[m]+" ");
                    }
                }

                Console.SetCursorPosition(5, 35);
                Musica();
                
                tecla = Console.ReadKey(true);
               
                if (tecla.Key == ConsoleKey.RightArrow) {
                    onde++;
                    if (onde > array.Length - 1) 
                        onde = 0; //dar a volta ao menu
                } else if (tecla.Key == ConsoleKey.LeftArrow) {
                    onde--;
                    if (onde < 0) 
                        onde = Convert.ToInt16(array.Length - 1);  // dar a volta por cima
                }

            } while (tecla.Key != ConsoleKey.Enter);

            return onde; // return
        }

   

        static void SairPrograma() {
  
            Console.Clear();
            language.lingua6();  

            //MENU\\
            int opcao = upDownArrow(language.lingua6()); // Selecção

            if (opcao == 0) {
                
                Environment.Exit(0);
            }else{
                Console.Clear();
                MenuPrincipal();
            }
        }


        static void Musica() { // Botão da Música

            if (tecla.Key == ConsoleKey.M) {

                condition = !condition;

                if (condition) { 
                  DireStraits.PlayLooping();
                  symbol = "[◄»]";
                }else{
                  DireStraits.Stop();
                  symbol = "[◄ ]";
                }
            }

            Console.Write(symbol);
        }

        static void showAboutMusic() { // Botão da Música

             if(language.getLingua() == 0) { 
                  Console.Write("\t\t[S]obre   ");
                  Console.Write("[M]usica");
             }else{
                  Console.Write("\t\t[A]bout   ");
                  Console.Write("[M]usic");  
             }
        }

        //efeito spinning
        static bool efeitoSlot(string[] arraySlot, int[] casa,  int jogo, bool[] vitoria, int aposta, int multiplicador) { 

            int n = 0; //incrementadora

            //Opcoes do Efeito
            int velocidade = 40; // Velocidade
            int tempo = 70;     // Duração do Spin
            int cursor = 15;   // Altura do Spin
            int nVitorias = 0;
           
            Console.SetCursorPosition(2, 12);
            AlavancaBaixa();
            
            jogosJogados += 1;

            for (int i = 0; n < tempo; i++) {

               if (n >= 0 && n < 40) //efeito para abrandar
                    System.Threading.Thread.Sleep(velocidade);

               if (n >= 40 && n < 60)
                    System.Threading.Thread.Sleep(velocidade + 30);
                
               if (n >= 60)
                    System.Threading.Thread.Sleep(velocidade + 45);

               if (jogo == 0) { //está um pouco para a direita para evitar que o cursor pisque nos brackets
                Console.SetCursorPosition(23, cursor);
                Console.Write($" [{arraySlot[i % 10]}]         [{arraySlot[i % 9]}]        [{arraySlot[i % 8]}]");
                
               }else if(jogo == 1) {
                Console.SetCursorPosition(17, cursor);
                Console.Write($" [{arraySlot[i % 10]}]         [{arraySlot[i % 9]}]         [{arraySlot[i % 8]}]         [{arraySlot[i % 10]}]");
               
               }else{
                Console.SetCursorPosition(23, 13);
                Console.Write($" [{arraySlot[i % 10]}]         [{arraySlot[i % 8]}]        [{arraySlot[i % 9]}]");

                Console.SetCursorPosition(24, 15);
                Console.Write($"[{arraySlot[i % 9]}]         [{arraySlot[i % 10]}]        [{arraySlot[i % 8]}]");

                Console.SetCursorPosition(24, 17);
                Console.Write($"[{arraySlot[i % 8]}]         [{arraySlot[i % 9]}]        [{arraySlot[i % 10]}]");
               }

                n++; 
            }

            //Resultado Final + Condicoes

              if (jogo == 0) { 
               
                if (casa[3] == casa[4] && casa[3] == casa[5]) { 
                        Console.ForegroundColor = ConsoleColor.Red;
                        vitoria[0] = true;
                        
                }

                Console.SetCursorPosition(24, cursor); 
                Console.Write($"[{arraySlot[casa[3]]}]         [{arraySlot[casa[4]]}]        [{arraySlot[casa[5]]}]");
                
              }else if(jogo == 1) {

                if (casa[3] == casa[4] && casa[3] == casa[5] && casa[3] == casa[9]) { 
                        Console.ForegroundColor = ConsoleColor.Red;
                        vitoria[1] = true;
                }

                Console.SetCursorPosition(18, cursor);
                Console.Write($"[{arraySlot[casa[3]]}]         [{arraySlot[casa[4]]}]         [{arraySlot[casa[5]]}]         [{arraySlot[casa[9]]}]");

              }else {
                
                Console.SetCursorPosition(24, 13);
                Console.Write($"[{arraySlot[casa[0]]}]         [{arraySlot[casa[1]]}]        [{arraySlot[casa[2]]}]");

                Console.SetCursorPosition(24, 15);
                Console.Write($"[{arraySlot[casa[3]]}]         [{arraySlot[casa[4]]}]        [{arraySlot[casa[5]]}]");

                Console.SetCursorPosition(24, 17);
                Console.Write($"[{arraySlot[casa[6]]}]         [{arraySlot[casa[7]]}]        [{arraySlot[casa[8]]}]");


                 if (casa[8] == casa[4] && casa[8] == casa[0]) { 
                        vitoria[2] = true;
                 }

                 if (casa[7] == casa[4] && casa[7] == casa[1]) { 
                       vitoria[3] = true;
                 }

                 if (casa[6] == casa[4] && casa[6] == casa[2]) { 
                       vitoria[4] = true;
                 }

                 if (casa[3] == casa[4] && casa[3] == casa[5]) { 
                       vitoria[5] = true;
                 }
              }

            Console.SetCursorPosition(2, 12);
            Alavanca();
           
              foreach(bool b in vitoria)
                    if(b)
                        nVitorias++;

                if(nVitorias > 0) { 
                    jogosGanhos += 1;
                        Console.ReadKey();
                            parabens(aposta, multiplicador, nVitorias);
                                return true;
                }else{
                    creditos -= aposta;
                        jogosPerdidos += 1;
                }

            return false;
        }


        static int tipoJogo() // + Jogador
        {    

            Console.Clear();
            string[] tipo = { "3-Slot", "4-Slot", "9-Slot"};
            
            visorTipoJogo();
            
            Console.SetCursorPosition(22, 11);
            language.tipoJogo();

            int opcao = leftRigthArrow(tipo, cor, 14); //Seleccao do Tipo de Slot

            if(user == null)
                Utilizador();

       
            
      

            if (user == null){ 

                if (language.getLingua() == 0){

                Console.SetCursorPosition(30, 21);
                Console.Write("Nome do Jogador");
                }else{

                Console.SetCursorPosition(30, 21);
                Console.Write("  Player Name");
                }

                if(user == null) { 

                if (language.getLingua() == 0){
                Console.SetCursorPosition(20, 16);
                Console.Write("[Slot Escolhida, digite o seu nome]");
                }else{
                Console.SetCursorPosition(23, 16);
                Console.Write("[Slot Chosen, type your name]");
                }

                Console.ForegroundColor = cor;
                Console.SetCursorPosition(34, 23);
                user =  Console.ReadLine();

                }
               
            }
        
        return opcao;
        }


        static void SlotMachine(string[] arraySlot, int multiplicador) { // Lógica da slot machine com 1 fila, dificuldade variável

            string[] quanto = { "100", "200", "300", "500", "X" };
            int[] casa = new int[10];
            bool[] vitoria = {false, false, false, false, false, false, false, false, false, false}; //inicialização

            Random aleatorio = new Random();
            ConsoleKeyInfo tecla;
            ConsoleColor corAposta = ConsoleColor.Yellow;
            Console.Clear();

            int aposta, opcao;
            int jogo = tipoJogo();

            for (; ;){

                for(int i = 0; i < casa.Length; i++)
                    casa[i] = aleatorio.Next(dificuldade);

                jacktopSlotMachine();   //Topo da Caixa
                jacktopSlotMachine2(); //Fundo da Caixa
                visorAposta();        //Visor da Aposta      
                Alavanca();
                mostrarPontuacao();
                
                if(language.getLingua() == 0) { 
                    Console.SetCursorPosition(27, 8);
                    Console.Write(" Creditos:[        ]");
                }else{
                    Console.SetCursorPosition(27, 8);
                    Console.Write(" Credits:[         ]");
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(40, 8);
                Console.Write(creditos);
                Console.ResetColor();

                opcao = leftRigthArrow(quanto, corAposta, 22);
                
                switch (opcao) {

                    case 0: aposta = 100; break;
                    case 1: aposta = 200; break;
                    case 2: aposta = 300; break;
                    case 3: aposta = 500; break;
                    default: Console.Clear();
                        return; //para sair da funcao
                }

               if(efeitoSlot(arraySlot, casa, jogo, vitoria, aposta, multiplicador))
                    return;
               
               tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.Escape) {
                     Console.Clear();
                     break;
                }
                
            }
        
        }

        static int parabens(int aposta, int multiplicador, int nVitorias) {

        multiplicador += 1;

        Console.SetCursorPosition(24, 13);
        Console.Write($"                                    ");

        Console.SetCursorPosition(18, 15);
        Console.Write($"                                         ");

        Console.SetCursorPosition(24, 17);
        Console.Write($"                                    ");


        for (int i = 0; i < 30; i++) {
        System.Threading.Thread.Sleep(100);
        
        if (i % 2 == 0)
            Console.ForegroundColor = ConsoleColor.DarkGreen;
         else 
            Console.ForegroundColor = ConsoleColor.DarkYellow;

        Console.SetCursorPosition(24, 15);
        Console.Write("  █ ▄▀▄ ▄▀▀ █▄▀ █▀▄ ▄▀▄ ▀█▀");
        Console.SetCursorPosition(24, 16);
        Console.Write("▀▄█ █▀█ ▀▄▄ █ █ █▀  ▀▄▀  █");
        }
            Console.Clear();
            return creditos += aposta * (multiplicador + nVitorias);
        }


        //Leitura & Escrita

        static void Salvar()
        {

        string jj = jogosJogados.ToString();
        string jp = jogosPerdidos.ToString();
        string jg = jogosGanhos.ToString();

        string[] jogos = { jj, jg, jp };

        System.IO.File.WriteAllLines(path, jogos);

        using (System.IO.StreamWriter file = new System.IO.StreamWriter(path2, true)){
            if(user != null || user.Length > 0)
                file.WriteLine(creditos.ToString() + " " +  user);
          }

        }

        static void Highscore() {
        Console.Clear();

        string[] utilizadores = System.IO.File.ReadAllLines(path2);
        int num = 20;
        string aux = null;

        visorHighscore();
        corpoHighscore();

        Console.SetCursorPosition(25, 4);
        language.highscore();

        if(language.getLingua() == 0) {
        Console.SetCursorPosition(32, 10);
        Console.WriteLine("  Jogos");
        Console.SetCursorPosition(15, 13);
        Console.WriteLine(" Jogados");
        Console.SetCursorPosition(33, 13);
        Console.WriteLine(" Ganhos");
        Console.SetCursorPosition(48, 13);
        Console.WriteLine("  Perdidos");
        Console.SetCursorPosition(32, 18);
        Console.WriteLine(" Pontuação");

        }
        else{
        Console.SetCursorPosition(32, 10);
        Console.WriteLine(" Games  ");
        Console.SetCursorPosition(15, 13);
        Console.WriteLine("  Played");
        Console.SetCursorPosition(33, 13);
        Console.WriteLine("  Won");
        Console.SetCursorPosition(48, 13);
        Console.WriteLine("    Lost");
        Console.SetCursorPosition(32, 18);
        Console.WriteLine(" Highscore");
        }

        Console.ForegroundColor = cor;
        Console.SetCursorPosition(31, 11);
        Console.WriteLine("   ═════");
        Console.SetCursorPosition(32, 19);
        Console.WriteLine(" ═════════\n");
        Console.SetCursorPosition(15, 14);
        Console.WriteLine(" ════════  \t ════════  \t  ════════");
        Console.ResetColor();

        Console.SetCursorPosition(15, 15);
        Console.Write("    {0}     \t    {1}     \t     {2}", jogosJogados, jogosGanhos, jogosPerdidos);
       
        //Array.Sort(utilizadores);


        for (int i = 0; i < utilizadores.Length - 1; i++){
           for(int j = i + 1; j < utilizadores.Length; j++){
                if (Convert.ToInt32(utilizadores[i].Substring(0, utilizadores[i].IndexOf(' '))) < Convert.ToInt32(utilizadores[j].Substring(0, utilizadores[j].IndexOf(' ')))){ 
                    aux = utilizadores[i]; 
                    utilizadores[i] = utilizadores[j]; 
                    utilizadores[j] = aux; 
                }     

           }
           
        }

        for (int i = 0; i < utilizadores.Length; i++) {
            Console.SetCursorPosition(15, num++);
                Console.WriteLine(utilizadores[i]);
        }

        tecla = Console.ReadKey(true);

        if (tecla.Key == ConsoleKey.Escape || tecla.Key == ConsoleKey.Enter)
        {
          Console.Clear();
            return;
        }


        }



        static void corpoHighscore(){

        Console.ForegroundColor = cor;
        Console.WriteLine("\t╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("\t║ ╔════════════════════════════════════════════════════╗ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.WriteLine("\t║ ║                                                    ║ ║");
        Console.ResetColor();
        }


        static void visorHighscore(){

        Console.ForegroundColor = cor;
        Console.SetCursorPosition(21, 3);
        Console.WriteLine("╔════════════════════════════════╗");
        Console.SetCursorPosition(21, 4);
        Console.WriteLine("║                                ║");
        Console.SetCursorPosition(21, 5);
        Console.WriteLine("╚════════════════════════════════╝\n");
        Console.ResetColor();
        }

        static void Utilizador(){

        Console.ForegroundColor = cor;
        Console.SetCursorPosition(26, 20);
        Console.WriteLine("╔═════════════════════╗");
        Console.SetCursorPosition(26, 21);
        Console.WriteLine("║                     ║");
        Console.SetCursorPosition(26, 22);
        Console.WriteLine("╚═════════════════════╝\n");
        Console.ResetColor();
        }

        static void mostrarPontuacao()
        {

        Console.ForegroundColor = cor;
        Console.SetCursorPosition(26, 7);
        Console.WriteLine("╔═════════════════════╗");
        Console.SetCursorPosition(26, 8);
        Console.WriteLine("║                     ║");
        Console.SetCursorPosition(26, 9);
        Console.WriteLine("╚═════════════════════╝\n");
        Console.ResetColor();
        }



































    }
}
