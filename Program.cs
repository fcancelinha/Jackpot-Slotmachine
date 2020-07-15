using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SlotMachine_1._1
{
    class Program
    {
        public static void Main(string[] args)
        {
           
            Console.Title = "JACKPOT -- C#";
            Console.SetWindowSize(75, 40);

            MenuPrincipal();
            Console.ReadKey();
           
        }

        /* 
         ===================================================================================================================================================== 
          Nome.   Filipe Miguel Rosário
          Email.  fmcancelinha@gmail.com

          About.  Jogo simples que simula uma slot machine de 1 ou 3 filas
          Versao. 1.a.4
          Modulo. C#

          TO-DO:

          IMPORTANTE:. Pontos e apostas(quanto mais apostas mais ganhas ou perdes) + Gráfico da slot machine com vara a descer, Música Main Menu + Música Spin
          SECUNDÀRIO:. Guardar Utilizador em Ficheiro ?, texto de parabéns, slot machine 3 filas bidimensional.
          $@" + pastel
         ======================================================================================================================================================   
         */


        // Variáveis Globais

        //default settings (caso nenhuma opcao seja seleccionada)
        private static string[] simbolos = new string[10] { "♠", "♣", "♥", "♦", "◊", "Ω", "Ψ", "Φ", "λ", "π" };
        private static int dificuldade = 4;
        private static int creditos = 1000;

        //Cores
        private static ConsoleColor cor = ConsoleColor.DarkRed;


        static void jacktopInterface(ConsoleColor cor)
        {
            Console.WriteLine($@"     ██╗ █████╗  ██████╗██╗  ██╗██████╗  ██████╗ ████████╗
                                      ██║██╔══██╗██╔════╝██║ ██╔╝██╔══██╗██╔═══██╗╚══██╔══╝       
                                      ██║███████║██║     █████╔╝ ██████╔╝██║   ██║   ██║   



            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Apresenta estética
            Console.ForegroundColor = cor;
            Console.WriteLine("\n");
            Console.WriteLine("\t     ██╗ █████╗  ██████╗██╗  ██╗██████╗  ██████╗ ████████╗");
            Console.WriteLine("\t     ██║██╔══██╗██╔════╝██║ ██╔╝██╔══██╗██╔═══██╗╚══██╔══╝");
            Console.WriteLine("\t     ██║███████║██║     █████╔╝ ██████╔╝██║   ██║   ██║   ");
            Console.WriteLine("\t██   ██║██╔══██║██║     ██╔═██╗ ██╔═══╝ ██║   ██║   ██║   ");
            Console.WriteLine("\t╚█████╔╝██║  ██║╚██████╗██║  ██╗██║     ╚██████╔╝   ██║   ");
            Console.WriteLine("\t ╚════╝ ╚═╝  ╚═╝ ╚═════╝╚═╝  ╚═╝╚═╝      ╚═════╝    ╚═╝   ");
            Console.WriteLine("\t════════════════════════════════════════════════ by Filipe");
            Console.ResetColor();
            Console.WriteLine("\n\t                // Slot Machine \"JACKPOT\" " + "\\" + "\\");
            Console.WriteLine("\t     Use as teclas ↑ ou ↓ e ENTER para seleccionar\n");

        }

        static void jacktopLower(ConsoleColor cor)
        {
            Console.ForegroundColor = cor;
            Console.WriteLine("\n\n");
            Console.WriteLine("\t██║                                                     ██║");
            Console.WriteLine("\t██║                                                     ██║");
            Console.WriteLine("\t██║                                                     ██║");
            Console.Write("\t██║"); 
            Console.ResetColor(); Console.Write("Versão 1.a.4 - Jogo Slot Machine C#"); 
            Console.ForegroundColor = cor; 
            Console.WriteLine("\t\t\t██║");
            Console.WriteLine("\t██████████████████████████████████████████████████████████║");
            Console.WriteLine("\t╚═════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }

        static void jacktopSlotMachine(ConsoleColor cor) {

            Console.ForegroundColor = cor;
            Console.SetCursorPosition(23, 10);
            Console.WriteLine("\r\t╔════════════════════════════════════════════════════════╗");
            Console.WriteLine("\r\t║ ██████████████████████████████████████████████████████ ║");
            Console.WriteLine("\r\t║ ██══════════════════════════════════════════════════██ ║");
            Console.WriteLine("\r\t║ ██                                                  ██ ║");
            Console.WriteLine("\r\t║ ██                                                  ██ ║");
            Console.WriteLine("\r\t║ ██                                                  ██ ║");
            Console.ResetColor();
        }


        static void jacktopSlotMachine2(ConsoleColor cor){
            
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

        static ConsoleColor Colors(ConsoleColor cor)
        {
            
            string[] cores = new string[9] {"Vermelho", "Azul", "Cyan", "Cinzento", "Verde", "Magenta", "Amarelo", "Branco", "\n\t\t\t\t   Sair" };
            Console.Clear();

            int opcao = upDownArrow(cores, cor);

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

        static void JacktopPontos(int pontos) {

            Console.Write("\n\t     Créditos:[");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(pontos);
            Console.ResetColor();
            Console.Write("]$");
        }

        static int upDownArrow(string[] menu, ConsoleColor cor) { //Metodo Seleccionador 

            int onde = 0;  //Variavel localizadora
            ConsoleKeyInfo tecla;

            do {
                for (int m = 0; m < menu.Length; m++) { // Percorrer o Menu
                    Console.SetCursorPosition(0, 1);
                    jacktopInterface(cor);
                    if (onde == m){

                        Console.SetCursorPosition(33, m + 15);
                        Console.ForegroundColor = cor;        
                        Console.WriteLine(menu[m]);
                        Console.ResetColor();
                    } else {
                        Console.SetCursorPosition(33, m + 15);
                        Console.WriteLine(menu[m]);
                        Console.SetCursorPosition(0, 25);
                        JacktopPontos(creditos);
                        jacktopLower(cor);
                    }
                }

                tecla = Console.ReadKey(true);
               
                if (tecla.Key == ConsoleKey.DownArrow) {
                    onde++;
                    if (onde > menu.Length - 1) onde = 0; //dar a volta ao menu
                } else if (tecla.Key == ConsoleKey.UpArrow) {
                    onde--;
                    if (onde < 0) 
                        onde = Convert.ToInt16(menu.Length - 1);  // dar a volta por cima
                }
                //Escape
                if (tecla.Key == ConsoleKey.Escape) {
                    onde = menu.Length - 1; // Default vai sair por aqui
                    break;
                }
            } while (tecla.Key != ConsoleKey.Enter);

            return onde; // return
        }

        static void Opcoes(ConsoleColor cores) { // Opcoes

            string[] menu5 = {"  Tema", "Dificuldade", " Cores ", "\n\t\t\t\t   Sair" };
            Console.Clear();

            int opcoes = upDownArrow(menu5, cor);

            switch (opcoes) {

                case 0: simbolos = MenuTema(simbolos, cor); break;
                case 1: dificuldade = MenuDificuldade(cor); break;
                case 2: cor = Colors(cores)               ; break;
                default:
                    break;
            }
            Console.Clear();
        }

        static void Musica() {
            


        }



        static void MenuPrincipal() //Jogar
        {
            int opcao;

            ////////MENU///////
            string[] menu1 = { "Jogar", "Opções", "Música", "\n\t\t\t\t    Sair" };
           
            do
            {
                Console.SetCursorPosition(0, 10);
                opcao = upDownArrow(menu1, cor); //Seleccao

                switch (opcao)
                {
                    case 0: creditos = SlotMachine(simbolos, dificuldade, cor, creditos);
                        break;
                    case 1: Opcoes(cor);
                        break;
                    case 2:
                        break;
                    default:
                        break;
                }

            } while (opcao != 4);
        }

        static string[] MenuTema(string[] simbolos, ConsoleColor cor) //Escolha do tema da Slot Machine
        {

            ////////MENU///////
            string[] menu2 = { "Caracteres", "Letras", "Numeros", "Exotico", "\n\t\t\t\t   Sair" };
            Console.Clear();

            int opcao = upDownArrow(menu2, cor); //Seleccao

            switch (opcao) {

                case 0: simbolos = new string[10] { "!", "#", "$'", "%", "&", "=", "@", "~", "»", "«" };
                    break;
                case 1: simbolos = new string[10] { "C", "A", "M", "B", "M", "L", "P", "U", "Z", "N" };
                    break;
                case 2: simbolos = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
                    break;
                case 3: simbolos = new string[10] { "♠", "♣", "♥", "♦", "◊", "Ω", "Ψ", "Φ", "λ", "π" };
                    break;
                default:
                    break;
            }
            Console.Clear();
            return simbolos; //return
        }

        static int MenuDificuldade(ConsoleColor cor) {  // Escolha de dificuldade -- 1 Fila

            int dificuldade = 0;

            ////////MENU///////
            string[] menu3 = { " Fácil", " Médio", " Difícil", " 20 a C#", "\n\t\t\t\t   Sair" };
            Console.Clear();

            int opcao = upDownArrow(menu3, cor); //Seleccao

            switch (opcao) { // Basta mudar os numeros para modificar a dificuldade (> o numero; <% de acertar)
                case 0: dificuldade = 5; break;
                case 1: dificuldade = 7; break;
                case 2: dificuldade = 10; break;
                case 3: dificuldade = 10; break;
                default:
                    break;
            }
            Console.Clear();
            return dificuldade;
            
        }

        static void efeitoSlot(string[] arraySlot, int velocidade, int tempo, string grafico, ConsoleColor cor) { //efeito spinning slot 1  
            int n = 0;
            Console.ForegroundColor = cor;
            for (int i = 0; n < tempo; i++)
            {
                System.Threading.Thread.Sleep(velocidade);
                Console.OutputEncoding = System.Text.Encoding.UTF8; // Enconding para mostrar simbolos UTF-8
                Console.Write($"\r{grafico}\t\t[{arraySlot[i % 10]}]         [{arraySlot[i % 9]}]        [{arraySlot[i % 8]}]");
                n++;
            }

        }

        static int SlotMachine(string[] arraySlot, int dificuldade, ConsoleColor cor, int pontos) { // Lógica da slot machine com 1 fila, dificuldade variável

            Random aleatorio = new Random();
            ConsoleKeyInfo tecla;
            Console.Clear(); // -- IMPORTANTE MUDA O UI COMPLETAMENTE
            string grafico = "\r\t║ ██";


            //Main Settings
            int velocidade = 50; // Velocidade
            int tempo = 30;     // Duração do Spin
            int cursor = 15;   // Altura do Spin
            
            int casa1, casa2, casa3;

            for(; ;){

                casa1 = aleatorio.Next(dificuldade);
                casa2 = aleatorio.Next(dificuldade);
                casa3 = aleatorio.Next(dificuldade);

             
                    jacktopSlotMachine(cor); //grafico inicial
                    jacktopSlotMachine2(cor); //grafico final

                    Console.SetCursorPosition(24, cursor);
                    efeitoSlot(arraySlot, velocidade, tempo, grafico, cor);

               
                Console.Write($"\r{grafico}\t\t[{arraySlot[casa1]}]         [{arraySlot[casa2]}]        [{arraySlot[casa3]}]");
                Console.ResetColor();

                if(casa1 == casa2 && casa1 == casa2 && casa1 == casa3){
                    pontos = parabens(pontos);
                    break;
                }else{
                    pontos = deNovo(pontos);
                    tecla = Console.ReadKey(true);
                    Console.SetCursorPosition(20, 22);
                    Console.Write("                                   ");

                    if (tecla.Key == ConsoleKey.Escape) {
                        Console.Clear();
                        break;
                        }
                }
            }
            return pontos;
        }

        static int parabens(int pontos) {
            Console.SetCursorPosition(20, 22);
            Console.Write("         Parabéns !! Ganhou... \n\t\tPressione qualquer tecla para voltar ao menu");
            Console.ReadKey();
            Console.Clear();

            pontos += 1000;

            return pontos;
        }

        static int deNovo(int pontos) {
            Console.SetCursorPosition(20, 22);
            Console.Write("Pressione Enter para jogar de novo");

            pontos -= 100;

            return pontos;
        }














































    }
}
