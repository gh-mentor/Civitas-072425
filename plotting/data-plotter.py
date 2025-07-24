"""
This app uses Python, numpy, matplotlib, and pandas to generate a set of data points and plot them on a graph.
"""

# Import necessary libraries and document each step
import numpy as np                  # NumPy for numerical operations
import matplotlib.pyplot as plt     # Matplotlib for plotting graphs
import pandas as pd                 # Pandas for data manipulation



"""
Create a function 'gen_data' that generates a set of data points (x, f(x)) and returns them as a pandas data frame.
Arguments:
- 'x_range' is a tuple of two integers representing the range of x values to generate.
Returns:
- A pandas data frame with two columns, 'x' and 'y'.
Details:
- 'x' values are generated randomly between x_range[0] and x_range[1].
- 'y' values are generated as a non-linear function of x with excessive random noise: y = x ^ 1.5  + noise.
- The data frame is sorted by the 'x' values.
Error Handling:
- If the input range is invalid (e.g., x_range[0] >= x_range[1]), an error is raised.
- If the input range is not a tuple of two integers, an error is raised.
Example:
- gen_data((0, 100)) returns a data frame with 'x' values between 0 and 100 and 'y' values calculated as described.
"""
def generate_data(x_range=(0, 100), n=100):
    if not isinstance(x_range, tuple) or len(x_range) != 2:
        raise ValueError("x_range must be a tuple of two integers.")
    if x_range[0] >= x_range[1]:
        raise ValueError("Invalid range: x_range[0] must be less than x_range[1].")
    
    x = np.random.uniform(x_range[0], x_range[1], n)
    noise = np.random.normal(0, 10, n)  # Excessive noise
    y = x ** 1.5 + noise
    
    data = pd.DataFrame({'x': x, 'y': y})
    return data.sort_values(by='x').reset_index(drop=True)

"""
Create a function 'plot_data' that plots the data points from the data frame. The copilot response should contain python docstrings for the function.
Arguments:
- 'data' is a pandas data frame with two columns, 'x' and 'y'.
Returns:
- None
Details:
- The function uses matplotlib to create a scatter plot of the data points.
- The x-axis is labeled 'X values' and the y-axis is labeled 'Y values'.
- The plot is displayed using plt.show().
Error Handling:
- If the input data is not a pandas data frame or does not contain the required columns, an error is raised.
Example:
- plot_data(data) displays a scatter plot of the data points in the data frame.
"""
def plot_data(data):
    if not isinstance(data, pd.DataFrame) or 'x' not in data.columns or 'y' not in data.columns:
        raise ValueError("Input data must be a pandas DataFrame with 'x' and 'y' columns.")
    
    plt.figure(figsize=(10, 6))
    plt.scatter(data['x'], data['y'], color='blue', label='Data Points')
    plt.title('Scatter Plot of Data Points')
    plt.xlabel('X values')
    plt.ylabel('Y values')
    plt.legend()
    plt.grid(True)
    plt.show()

"""
Create a function 'main' that generates a set of data points, plots them, and returns the data frame.
Arguments:
- 'x_range' is a tuple of two integers representing the range of x values to generate
Returns:
- A pandas data frame with two columns, 'x' and 'y'.
"""
def main(x_range=(0, 100)):
    data = generate_data(x_range)
    plot_data(data)
    return data

if __name__ == "__main__":
    # Example usage
    data = main((0, 100))
    print(data.head())  # Display the first few rows of the generated data