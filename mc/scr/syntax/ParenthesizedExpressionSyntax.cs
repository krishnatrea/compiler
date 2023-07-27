namespace Minsk.Syntax
{
    class ParenthesizedExpressionSyntax : ExpressionSyntax
    {

        public ParenthesizedExpressionSyntax(SyntaxToken OpenParenthesisToken, ExpressionSyntax expression, SyntaxToken CloseParenthesisToken)
        {
            this.OpenParenthesisToken = OpenParenthesisToken;
            Expression = expression;
            this.CloseParenthesisToken = CloseParenthesisToken;
        }
        public override SyntaxKind Kind => SyntaxKind.ParenthesisExpression;

        public SyntaxToken OpenParenthesisToken { get; }
        public ExpressionSyntax Expression { get; }
        public SyntaxToken CloseParenthesisToken { get; }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return OpenParenthesisToken;
            yield return Expression;
            yield return CloseParenthesisToken;

        }
    }

}
