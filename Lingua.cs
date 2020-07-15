using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine_1.a._2
{
    public class Lingua
    {
        //Estou a usar if's em vez de booleans para que no futuro possa adicionar outras linguas se preciso

        private int num;

        public Lingua()
        {
        this.num = 0;
        }

        public void setLingua(int num)
        {
        this.num = num;
        }

        public int getLingua()
        {
        return num;
        }

        public void lingua1()
        {
        if (num == 0)
            Console.Write("\t\t    Utilize ▲ e ▼, ENTER para seleccionar");
        else
            Console.Write("\t\t\t Use ▲ and ▼, ENTER to select");
        }

        public void lingua2()
        {
        if (num == 0)
            Console.Write("Versão 2.b - Jogo Slot Machine C#");
        else
            Console.Write("Version 2.b - Slot Machine Game C#");
        }


        public void lingua3()
        {
        if (num == 0)
            Console.Write("\n\t     Créditos:[");
        else
            Console.Write("\n\t     Credits:[");
        }

        public void highscore()
        {
       
        if (num == 0)
            Console.Write(" Pontuação & Estatística");
        else
            Console.Write("  Highscore & Statistic");
        }

        public void username()
        {

        if (num == 0)
            Console.Write("Utilizador:[");
        else
            Console.Write("User:[");
        }

        public void tipoJogo()
        {
        if (num == 0)
            Console.Write("Escolha o tipo de Slot Machine");
        else
            Console.Write(" Choose the Slot Machine type");
        }


        public string[] lingua4()
        {

        string[] cores;

        if (num == 0)
            cores = new string[9] { "Vermelho", "Azul", "Cyan", "Cinzento", "Verde", "Magenta", "Amarelo", "Branco", "\n\t\t\t\t  Sair" };
        else
            cores = new string[9] { "Red", "Blue", "Cyan", "Grey", "Green", "Magenta", "Yellow", "White", "\n\t\t\t\t  Exit" };

        return cores;

        }

        public string[] lingua5()
        {

        string[] opcoes;

        if (num == 0)
            opcoes = new string[5] { "Tema", "Dificuldade", "Cor", "Mudar Utilizador", "\n\t\t\t\t  Sair" };
        else
            opcoes = new string[5] { "Theme", "Difficulty", "UI Color", "Change Username", "\n\t\t\t\t  Exit" };

        return opcoes;

        }

        public string[] lingua6()
        {
        string[] sair;

        Console.SetCursorPosition(24, 14);

        if (num == 0)
        {
        sair = new string[2] { "\n\t\t\t\t     Sim", "\n\t\t\t\t     Não" };
        Console.Write("Tem a certeza que quer sair?");
        }
        else
        {
        sair = new string[2] { "\n\t\t\t\t     Yes", "\n\t\t\t\t     No" };
        Console.Write("Are you sure you want to exit?");
        }

        return sair;
        }

        public string[] principal()
        {

        string[] principal;

        if (num == 0)
            principal = new string[6] { "Jogar", "Opções", "Lingua", "Salvar", "Pontuação", "\n\t\t\t\t Sair" };
        else
            principal = new string[6] { "Play", "Options", "Language", "Save", "HighScore", "\n\t\t\t\t Exit" };

        return principal;
        }


        public string[] tema()
        {

        string[] menu2;

        if (num == 0)
            menu2 = new string[6] { "Caracteres", "Letras", "Numeros", "Exotico", "Dinheiro", "\n\t\t\t\t Sair" };
        else
            menu2 = new string[6] { "Symbols", "Letters", "Numbers", "Exotic", "Currency", "\n\t\t\t\t Exit" };

        return menu2;
        }

        public string[] dificuldade()
        {

        string[] menu3;

        if (num == 0)
            menu3 = new string[5] { "Fácil", "Médio", "Difícil", "20 a C#", "\n\t\t\t\t Sair" };
        else
            menu3 = new string[5] { "Easy", "Medium", "Hard", "A+ in C#", "\n\t\t\t\t Exit" };

        return menu3;
        }
    }
}
