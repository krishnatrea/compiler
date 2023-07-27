namespace Minsk.Syntax
{

    enum SyntaxKind {
        NumberToken,
        WhiteSpaceToken,
        PlusToken,
        MinusToken,
        StarToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        SlashToken,
        BadToken,
        EndOfFileToken,
        NumberExpression,
        BinaryExpression,
        ParenthesisExpression,
        LiteralExpression,
        UnaryExpression
    }

}
