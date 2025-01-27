namespace Nummercial_finalProject.Services
{

    public static class GlobalFunction
    {
        public static double A { get; set; } = 1;
        public static double B { get; set; } = 1;
        public static double C { get; set; } = 1;
        public static double N { get; set; } = 1;
    }

    public class ResultServices : IResultServices
    {
        private readonly AppDBContext _context;

        public ResultServices(AppDBContext context)
        {
            _context = context;
        }

        public List<Result> Solve(Problem problem)
        {
            ValidateProblem(problem);

            var f = ParseFunction(problem.NameFunction);
            var results = new List<Result>();

            double t = problem.InitialValue;
            double y = problem.Y0;
            double h = problem.H;
            int steps = (int)((problem.LastValue - problem.InitialValue) / h);

            results.Add(new Result { X = t, y = y });

          
            double t1 = t + h;
            double y1 = y + h * f(t, y);
            results.Add(new Result { X = t1, y = y1 });

          
            for (int i = 2; i <= steps; i++)
            {
                double tPrev = results[i - 2].X;
                double yPrev = results[i - 2].y;
                double tCurrent = results[i - 1].X;
                double yCurrent = results[i - 1].y;

                double tNext = tCurrent + h;
                double yNext = yCurrent + (h / 2) * (3 * f(tCurrent, yCurrent) - f(tPrev, yPrev));

                results.Add(new Result { X = tNext, y = yNext });
            }

            return results;
        }

        public async Task<List<ResultR>> Rangku(ProblemR problem)
        {

       
            var f = ParseFunction(problem.NameFunction);

           
            var results = new List<ResultR>();

        
            double t = problem.InitialValue;
            double y = problem.Y0;

           
            results.Add(new ResultR { X = t, y = y });

           
            for (int i = 1; i <= problem.N; i++)
            {
          
                double k1 = problem.H * f(t, y);
                double k2 = problem.H * f(t + (problem.H / 2), y + k1 / 2);
                double k3 = problem.H * f(t + (problem.H / 2), y + k2 / 2);
                double k4 = problem.H * f(t + problem.H, y + k3);

                y = y + (k1 + 2 * k2 + 2 * k3 + k4) / 6;

           
                t = t + (problem.H);

                results.Add(new ResultR { X = t, y = y });
            }

            
            return await Task.FromResult(results);
        }

        private void ValidateProblem(Problem problem)
        {
            if (problem == null)
                throw new ArgumentNullException(nameof(problem));

            if (problem.H <= 0)
                throw new ArgumentException("Step size (h) must be greater than zero.");
        }

        private Func<double, double, double> ParseFunction(string functionName)
        {
            var functionMap = new Dictionary<string, Func<double[], double>>(StringComparer.OrdinalIgnoreCase)
          {
        { "sin", parameters => Math.Sin(parameters[0]) },
        { "cos", parameters => Math.Cos(parameters[0]) },
        { "exp", parameters => Math.Exp(parameters[0]) },
        { "log", parameters => parameters.Length == 1 ? Math.Log(parameters[0]) : Math.Log(parameters[0], parameters[1]) },
        { "log10", parameters => Math.Log10(parameters[0]) },
        { "log2", parameters => Math.Log(parameters[0], 2) },
        { "sqrt", parameters => Math.Sqrt(parameters[0]) },
        { "tan", parameters => Math.Tan(parameters[0]) },
        { "pow", parameters => Math.Pow(parameters[0], parameters[1]) },
        { "abs", parameters => Math.Abs(parameters[0]) },
        { "tanh", parameters => Math.Tanh(parameters[0]) },
        { "sinh", parameters => Math.Sinh(parameters[0]) },
        { "cosh", parameters => Math.Cosh(parameters[0]) },
        { "asin", parameters => Math.Asin(parameters[0]) },
        { "acos", parameters => Math.Acos(parameters[0]) },
        { "atan", parameters => Math.Atan(parameters[0]) },
        { "ceil", parameters => Math.Ceiling(parameters[0]) },
        { "floor", parameters => Math.Floor(parameters[0]) },
        { "round", parameters => Math.Round(parameters[0]) },
        { "min", parameters => Math.Min(parameters[0], parameters[1]) },
        { "max", parameters => Math.Max(parameters[0], parameters[1]) },
        { "if", parameters => parameters[0] != 0 ? parameters[1] : parameters[2] }
    };

            return (x, y) =>
            {
                try
                {
                    string modifiedFunctionName =
                    System.Text.RegularExpressions.Regex.Replace(
                        functionName,
                        @"\bx\b",
                        "t"
                    );

                    modifiedFunctionName = 
                    System.Text.RegularExpressions.Regex.Replace(
                        modifiedFunctionName,
                        @"(\w+)\s*\^\s*(\w+)",
                        "pow($1, $2)"
                    );

                    modifiedFunctionName = 
                    modifiedFunctionName.Replace("(^", "^").Replace("^)", "^");

                    var expression = new Expression(modifiedFunctionName);
                    expression.Parameters["t"] = x;
                    expression.Parameters["y"] = y;

                    expression.EvaluateFunction += (name, args) =>
                    {
                        var parameters = new double[args.Parameters.Count()];
                        for (int i = 0; i < args.Parameters.Count(); i++)
                        {
                            if (!double.TryParse(args.Parameters[i].Evaluate().ToString(), out parameters[i]))
                            {
                                throw new InvalidOperationException($"Invalid parameter at index {i}.");
                            }
                        }

                        if (functionMap.TryGetValue(name, out var function))
                        {
                            args.Result = function(parameters);
                        }
                        else
                        {
                            throw new InvalidOperationException($"Function '{name}' is not supported.");
                        }
                    };

                    expression.Parameters["pi"] = Math.PI;
                    expression.Parameters["e"] = Math.E;

                    return Convert.ToDouble(expression.Evaluate());
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException($"Error parsing or evaluating the function: {functionName}", ex);
                }
            };
        }
     
    }
}





