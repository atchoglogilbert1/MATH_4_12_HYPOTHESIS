# Hypothesis Testing

**Hypothesis testing determines whether the evidence gathered from a sample is strong enough to support a general claim about a larger population.**

## Example

- **Evidence gathered:** The new algorithm was faster in the test runs.
- **General claim:** The new algorithm is genuinely faster overall.
- **Question:** Is the observed difference convincing, or could it simply be caused by random variation?

Hypothesis testing helps answer this question.

## Null vs Alternative

- **Null hypothesis:** \(H_0\) — The new algorithm is not faster.
- **Alternative hypothesis:** \(H_1\) — The new algorithm is faster.

## Hypothesis Rejection

- **Null hypothesis:** The new algorithm is not genuinely faster.
- **Alternative hypothesis:** The new algorithm is genuinely faster.
- **Reject the null hypothesis:** The evidence is strong enough to conclude that the new algorithm is genuinely faster.
- **Fail to reject the null hypothesis:** The evidence is not strong enough to make that conclusion.

Failing to reject the null hypothesis does **not** prove that both algorithms are equally fast. It only means that the available evidence is insufficient.

## Alternative Hypothesis

The **alternative hypothesis is not necessarily what we want to happen**. It is the specific effect or difference we are testing for.


## Significance Level

The **lower the significance level**, the **stronger the evidence must be** before you can reject the null hypothesis.


- \(\alpha = 0.10\): Relatively weak evidence may be accepted.
- \(\alpha = 0.05\): Stronger evidence is required.
- \(\alpha = 0.01\): Very strong evidence is required.

A lower significance level makes us more cautious about claiming that a genuine effect exists.


<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/cbd33e70-bf08-4df7-a295-43d0b212b0ba" />


## Values and Formulas

| Value | Formula | Result | Purpose |
|---|---|---:|---|
| Differences | \(d_i=\text{existing}_i-\text{new}_i\) | \(5,6,2,9,4,8,4,8,5,8\) ms | Measures the improvement for each test case |
| Sample size | \(n=\text{number of pairs}\) | \(10\) | Number of paired measurements |
| Sum of differences | \(\sum d_i\) | \(59\) ms | Used to calculate the mean difference |
| Mean difference | \(\bar d=\frac{\sum d_i}{n}\) | \(5.9\) ms | Average improvement |
| Sum of squared deviations | \(\sum(d_i-\bar d)^2\) | \(46.9\) | Measures total variation around the mean |
| Sample variance | \(s_d^2=\frac{\sum(d_i-\bar d)^2}{n-1}\) | \(5.21\text{ ms}^2\) | Average squared variation |
| Sample standard deviation | \(s_d=\sqrt{s_d^2}\) | \(2.28\) ms | Measures how much the improvements vary |
| Standard error | \(SE=\frac{s_d}{\sqrt n}\) | \(0.72\) ms | Measures the uncertainty of the mean improvement |
| Test statistic | \(t=\frac{\bar d-0}{SE}\) | \(8.17\) | Compares the improvement with its uncertainty |
| Degrees of freedom | \(df=n-1\) | \(9\) | Selects the correct \(t\)-distribution |
| Significance level | Chosen before the test | \(\alpha=0.05\) | Defines how strong the evidence must be |
| Critical value | From the one-sided \(t\)-table using \(df=9\) and \(\alpha=0.05\) | \(1.833\) | Threshold for rejecting the null hypothesis |
| Decision rule | Reject \(H_0\) if \(t>t_{\text{critical}}\) | \(8.17>1.833\) | Determines the final decision |
| Final result | Based on the decision rule | Reject \(H_0\) | Evidence supports that the new algorithm is genuinely faster |



<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/df1af6b1-6d71-4ee6-b928-c192d5dcc402" />



