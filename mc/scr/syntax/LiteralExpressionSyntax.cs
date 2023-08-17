namespace Minsk.Syntax
{

    class LiteralExpressionSyntax : ExpressionSyntax
    {
        public LiteralExpressionSyntax(SyntaxToken literalToken, object value)
        {
            LiteralToken = literalToken;
            Value = value;
        }

         public LiteralExpressionSyntax(SyntaxToken literalToken)
          : this(literalToken, literalToken.Value)
        {
        }

        public override SyntaxKind Kind => SyntaxKind.LiteralExpression;

        public SyntaxToken LiteralToken { get; }
        public object Value { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
           yield return LiteralToken;

        }
    }

}
