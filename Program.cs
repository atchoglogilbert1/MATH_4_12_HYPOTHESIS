using System;

class Program
{
    static void Main()
    {
        double[] existingTimes =
        {
            52, 61, 48, 73, 55,
            68, 49, 71, 59, 65
        };

        double[] newTimes =
        {
            47, 55, 46, 64, 51,
            60, 45, 63, 54, 57
        };

        const double significanceLevel = 0.05;

        if (!MeasurementsAreValid(existingTimes, newTimes))
        {
            return;
        }

        double[] differences =
            CalculateDifferences(existingTimes, newTimes);

        double meanDifference =
            CalculateMean(differences);

        double standardDeviation =
            CalculateSampleStandardDeviation(
                differences,
                meanDifference
            );

        double standardError =
            CalculateStandardError(
                standardDeviation,
                differences.Length
            );

        if (standardError == 0)
        {
            Console.WriteLine(
                "The test cannot be performed because the variation is zero."
            );

            return;
        }

        double testStatistic =
            CalculateTestStatistic(
                meanDifference,
                standardError
            );

        int degreesOfFreedom =
            CalculateDegreesOfFreedom(differences.Length);

        double criticalValue =
            GetCriticalValue(
                degreesOfFreedom,
                significanceLevel
            );

        DisplayHypotheses();

        DisplayResults(
            differences.Length,
            degreesOfFreedom,
            meanDifference,
            standardDeviation,
            standardError,
            testStatistic,
            significanceLevel,
            criticalValue
        );

        MakeFinalDecision(
            testStatistic,
            criticalValue
        );
    }

    static bool MeasurementsAreValid(
        double[] existingTimes,
        double[] newTimes)
    {
        if (existingTimes.Length != newTimes.Length)
        {
            Console.WriteLine(
                "Both algorithms must have the same number of measurements."
            );

            return false;
        }

        if (existingTimes.Length < 2)
        {
            Console.WriteLine(
                "At least two paired measurements are required."
            );

            return false;
        }

        return true;
    }

    static double[] CalculateDifferences(
        double[] existingTimes,
        double[] newTimes)
    {
        double[] differences =
            new double[existingTimes.Length];

        for (int i = 0; i < existingTimes.Length; i++)
        {
            // A positive result means the new algorithm is faster.
            differences[i] =
                existingTimes[i] - newTimes[i];
        }

        return differences;
    }

    static double CalculateMean(double[] values)
    {
        double sum = 0;

        foreach (double value in values)
        {
            sum += value;
        }

        return sum / values.Length;
    }

    static double CalculateSampleStandardDeviation(
        double[] values,
        double mean)
    {
        double squaredDifferenceSum = 0;

        foreach (double value in values)
        {
            double distanceFromMean = value - mean;

            squaredDifferenceSum +=
                distanceFromMean * distanceFromMean;
        }

        double sampleVariance =
            squaredDifferenceSum / (values.Length - 1);

        return Math.Sqrt(sampleVariance);
    }

    static double CalculateStandardError(
        double standardDeviation,
        int sampleSize)
    {
        return standardDeviation / Math.Sqrt(sampleSize);
    }

    static double CalculateTestStatistic(
        double meanDifference,
        double standardError)
    {
        // The null hypothesis assumes a mean difference of zero.
        return meanDifference / standardError;
    }

    static int CalculateDegreesOfFreedom(int sampleSize)
    {
        return sampleSize - 1;
    }

    static double GetCriticalValue(
        int degreesOfFreedom,
        double significanceLevel)
    {
        /*
         * One-sided t-test:
         *
         * degrees of freedom = 9
         * significance level = 0.05
         *
         * Value obtained from a t-distribution table.
         */

        if (degreesOfFreedom == 9 &&
            significanceLevel == 0.05)
        {
            return 1.833;
        }

        throw new ArgumentException(
            "No critical value is stored for these test settings."
        );
    }

    static void DisplayHypotheses()
    {
        Console.WriteLine("One-sided paired t-test");
        Console.WriteLine();

        Console.WriteLine(
            "Null hypothesis:"
        );

        Console.WriteLine(
            "The new algorithm is not genuinely faster."
        );

        Console.WriteLine();

        Console.WriteLine(
            "Alternative hypothesis:"
        );

        Console.WriteLine(
            "The new algorithm is genuinely faster."
        );

        Console.WriteLine();
    }

    static void DisplayResults(
        int sampleSize,
        int degreesOfFreedom,
        double meanDifference,
        double standardDeviation,
        double standardError,
        double testStatistic,
        double significanceLevel,
        double criticalValue)
    {
        Console.WriteLine($"Sample size: {sampleSize}");

        Console.WriteLine(
            $"Degrees of freedom: {degreesOfFreedom}"
        );

        Console.WriteLine(
            $"Mean improvement: {meanDifference:F2} ms"
        );

        Console.WriteLine(
            $"Standard deviation: {standardDeviation:F2} ms"
        );

        Console.WriteLine(
            $"Standard error: {standardError:F2} ms"
        );

        Console.WriteLine(
            $"Test statistic: {testStatistic:F2}"
        );

        Console.WriteLine(
            $"Significance level: {significanceLevel}"
        );

        Console.WriteLine(
            $"Critical value: {criticalValue}"
        );

        Console.WriteLine();
    }

    static void MakeFinalDecision(
        double testStatistic,
        double criticalValue)
    {
        if (testStatistic > criticalValue)
        {
            Console.WriteLine(
                "Decision: Reject the null hypothesis."
            );

            Console.WriteLine(
                "Conclusion: The measurements provide sufficient " +
                "evidence that the new algorithm is genuinely faster."
            );
        }
        else
        {
            Console.WriteLine(
                "Decision: Fail to reject the null hypothesis."
            );

            Console.WriteLine(
                "Conclusion: The measurements do not provide sufficient " +
                "evidence that the new algorithm is genuinely faster."
            );
        }
    }
}