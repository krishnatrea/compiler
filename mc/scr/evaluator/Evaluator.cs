using Minsk.Binding;
using Minsk.Syntax;

namespace Minsk
{
    internal sealed class Evaluator
    {
        public Evaluator(BoundExpression root)
        {
            _root = root;
        }

        public readonly BoundExpression _root;

        public int Evaluate()
        {
            return EvaluateExpression(_root);
        }

        private int EvaluateExpression(BoundExpression node)
        {

            if (node is BoundLiteralExpression n)
            {
                return (int)n.Value;
            }

            if(node is BoundUnaryExpression u) {

                var operand = EvaluateExpression(u.Operand);

                if(u.OperatorKind == BoundUnaryOperatorKind.Negation) {
                    return -operand;
                }

                else if(u.OperatorKind == BoundUnaryOperatorKind.Identity) {
                    return operand;
                } else {
                    throw new Exception($"Unexpected unary operator {u.OperatorKind}");
                }

            }

            if (node is BoundBinaryExpression b)
            {

                var left = EvaluateExpression(b.Left);
                var right = EvaluateExpression(b.Right);

                switch (b.OperatorKind)
                {
                    case BoundBinaryOperatorKind.Addition:
                        return left + right;
                    case BoundBinaryOperatorKind.Subtraction:
                        return left - right;
                    case BoundBinaryOperatorKind.Division:
                        return left / right;
                    case BoundBinaryOperatorKind.Multiplication:
                        return left * right;
                    default:
                        throw new Exception($"Unexpected binary operator {b.OperatorKind}");
                }

            }

            // if(node is ParenthesizedExpressionSyntax p) {
            //     return EvaluateExpression(p.Expression);
            // }

            throw new Exception($"Unexpected node {node.Kind}");


        }
    }

}
