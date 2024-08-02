using System;
using Minsk.Binding;
using Minsk.Syntax;

namespace Minsk
{
    class Program
    {
        static void Main(string[] arg)
        {
            bool showTree = false;
            while (true)
            {
                Console.Write("> ");
                var line = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }

                if (line == "#showTree")
                {
                    showTree = !showTree;
                    Console.WriteLine(showTree ? "Showing the parse tree" : "it will not show the parse tree");
                    continue;
                }

                if (line == "#clear")
                {
                    Console.Clear();
                    continue;
                }

                var syntaxTree = SyntaxTree.Parse(line);
                var binder = new Binder();
                var boundExpression = binder.BindExpression(syntaxTree.Root);
                IReadOnlyList<string> diagnostics = syntaxTree.Diagnostics.Concat(binder.Diagnostics).ToArray();

                if (showTree)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    PrittyPrint(syntaxTree.Root);
                    Console.ResetColor();
                }

                if (!diagnostics.Any())
                {
                    var e = new Evaluator(boundExpression);
                    var result = e.Evaluate();
                    Console.WriteLine(result);

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    foreach (var error in syntaxTree.Diagnostics)
                    {
                        Console.WriteLine(error);
                    }
                    Console.ResetColor();

                }
            }
        }

        static void PrittyPrint(SyntaxNode node, string indent = "", bool isLast = true)
        {
            var marker = isLast ? "'---" : "|---";
            Console.Write(indent);
            Console.Write(marker);
            Console.Write(node.Kind);

            if (node is SyntaxToken t && t.Value != null)
            {
                Console.Write(" ");
                Console.Write(t.Value);
            }
            Console.WriteLine();
            indent += isLast ? "    " : "|  ";
            var lastChild = node.GetChildren().LastOrDefault();
            foreach (var child in node.GetChildren())
            {
                PrittyPrint(child, indent, child == lastChild);
            }
        }
    }

}
