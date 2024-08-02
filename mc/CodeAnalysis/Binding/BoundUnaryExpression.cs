namespace Minsk.CodeAnalysis.Binding
{
    internal sealed class BoundUnaryExpression : BoundExpression
    {

        public BoundUnaryExpression(BoundExpression operand, BoundUnaryOperatorKind operatorKind)
        {
            Operand = operand;
            OperatorKind = operatorKind;
        }

        public override Type Type => Operand.Type;

        public override BoundNodeKind Kind => BoundNodeKind.UnaryExpression;

        public BoundExpression Operand { get; }
        public BoundUnaryOperatorKind OperatorKind { get; }
    }
}
