namespace Minsk
{

    class NumberExpressionSyntax : ExpressionSyntax
    {
        public NumberExpressionSyntax(SyntaxToken numberToken)
        {
            this.NumberToken = numberToken;
        }

        public override SyntaxKind Kind => SyntaxKind.NumberExpression;

        public SyntaxToken NumberToken {get;}

        public override IEnumerable<SyntaxNode> GetChildren()
        {
           yield return NumberToken;
        }
    }

}
