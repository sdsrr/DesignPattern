using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode
{
    public class Expression
    {
        public virtual int Interpreter(Dictionary<string, int> param) { return 0; }
    }

    //变量解释器
    public class WordExpression : Expression
    {
        private string name;
        public WordExpression(string val) { name = val; }
        public override int Interpreter(Dictionary<string, int> param) { return param[name]; }
    }

    //符号解释器
    public class AddExpression : Expression
    {
        public Expression left;
        public Expression right;
        public AddExpression(Expression l, Expression r) { left = l; right = r; }
        public override int Interpreter(Dictionary<string, int> param)
        {
            return left.Interpreter(param) + right.Interpreter(param);
        }
    }

    public class SubExpression : Expression
    {
        public Expression left;
        public Expression right;
        public SubExpression(Expression l, Expression r) { left = l; right = r; }
        public override int Interpreter(Dictionary<string, int> param)
        {
            return left.Interpreter(param) - right.Interpreter(param);
        }
    }

    public class Calculator
    {
        private Expression exp;

        public int Calc(Dictionary<string, int> param)
        {
            return exp.Interpreter(param);
        }
        //从表达式构建解释器
        public void BuildExp(List<string> expression)
        {
            List<Expression> list = new List<Expression>();
            for (int i = 0; i < expression.Count; i++)
            {
                string param = expression[i];
                switch(param)
                {
                    case "+":
                        {
                            //使用左右字符解释器构建符号解释器(右字符还未创建，需要从参数中取)
                            Expression left = list[list.Count - 1];
                            list.RemoveAt(list.Count - 1);
                            Expression right = new WordExpression(expression[++i]);
                            list.Add(new AddExpression(left, right));
                        }
                        break;
                    case "-":
                        {
                            Expression left = list[list.Count - 1];
                            list.RemoveAt(list.Count - 1);
                            Expression right = new WordExpression(expression[++i]);
                            list.Add(new SubExpression(left, right));
                        }
                        break;
                    default:
                        {
                            list.Add(new WordExpression(param));
                        }
                        break;
                }
            }

            this.exp = list[list.Count - 1];
        }
    }

    //解释器模式:定义语言的文法，并且建立一个解释器来解释该语言(使用规定格式和语法的代码)中的句子
    class InterpreterPattern
    {
        /*
        static void Main(string[] args)
        {
            Calculator context = new Calculator();
            List<string> expression = new List<string> { "a","+","b","-","c"};//a+b-c
            Dictionary<string, int> param = new Dictionary<string, int> { { "a", 10 }, { "b", 1 }, { "c", -20 } };
            context.BuildExp(expression);
            int result = context.Calc(param);
            Console.WriteLine("result " + result);
            Console.ReadLine();
        }
        */
    }
}
