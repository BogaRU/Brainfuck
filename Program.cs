using System;
using System.Linq;
using NUnit.Framework;
using NUnitLite;

namespace func.brainfuck
{
    public class Program
    {
        private const string sierpinskiTriangleBrainfuckProgram = @"
                                >
                               + +
                              +   -
                             [ < + +
                            +       +
                           + +     + +
                          >   -   ]   >
                         + + + + + + + +
                        [               >
                       + +             + +
                      <   -           ]   >
                     > + + >         > > + >
                    >       >       +       <
                   < <     < <     < <     < <
                  <   [   -   [   -   >   +   <
                 ] > [ - < + > > > . < < ] > > >
                [                               [
               - >                             + +
              +   +                           +   +
             + + [ >                         + + + +
            <       -                       ]       >
           . <     < [                     - >     + <
          ]   +   >   [                   -   >   +   +
         + + + + + + + +                 < < + > ] > . [
        -               ]               >               ]
       ] +             < <             < [             - [
      -   >           +   <           ]   +           >   [
     - < + >         > > - [         - > + <         ] + + >
    [       -       <       -       >       ]       <       <
   < ]     < <     < <     ] +     + +     + +     + +     + +
  +   .   +   +   +   .   [   -   ]   <   ]   +   +   +   +   +
";

        public static void Main(string[] args)
        {
            if (args.Contains("test"))
                new AutoRun().Execute(new string[0]); // Запуск тестов
            else
            {
                Brainfuck.Run(sierpinskiTriangleBrainfuckProgram, Console.Read, Console.Write);
                Console.WriteLine("Это была демонстрация Brainfuck на примере построения треугольника Серпинского\n\n" +
                                  "Вы можете ввести свою комманду на языке brainfuck и получить её рсшифровку:\n");
                Brainfuck.Run(Console.ReadLine(), Console.Read, Console.Write);
            }
            Console.ReadKey();
        }
    }
}