using System;

namespace DataLayerModel
{
    /// <summary>
    /// Represents an employee with identifying and payroll information.
    /// </summary>
    public class Employee
    {
        private int? m_EmployeeID;
        private int? m_DepartmentID;
        private string? m_FirstName;
        private string? m_LastName;
        private double? m_HourlyRate;

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        /// <param name="departmentID">The unique identifier for the department. Must be a positive integer.</param>
        /// <param name="firstName">The first name of the employee. Cannot be null or empty.</param>
        /// <param name="lastName">The last name of the employee. Cannot be null or empty.</param>
        /// <param name="hourlyRate">The hourly rate for the employee. Must be a non-negative number.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when <paramref name="departmentID"/> is null or less than 1,
        /// <paramref name="firstName"/> or <paramref name="lastName"/> is null or empty,
        /// or <paramref name="hourlyRate"/> is null or negative.
        /// </exception>
        public Employee(int? departmentID, string? firstName, string? lastName, double? hourlyRate)
        {
            if (departmentID == null || departmentID < 1)
                throw new ArgumentException("DepartmentID must be a positive integer.", nameof(departmentID));
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("FirstName cannot be null or empty.", nameof(firstName));
            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("LastName cannot be null or empty.", nameof(lastName));
            if (hourlyRate == null || hourlyRate < 0)
                throw new ArgumentException("HourlyRate must be a non-negative number.", nameof(hourlyRate));

            m_DepartmentID = departmentID;
            m_FirstName = firstName;
            m_LastName = lastName;
            m_HourlyRate = hourlyRate;
        }

        /// <summary>
        /// Gets or sets the unique identifier for the employee.
        /// Must be a non-negative integer or <c>null</c>.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when the value is not <c>null</c> and is less than zero.
        /// </exception>
        public int? EmployeeID
        {
            get => m_EmployeeID;
            set
            {
                if (value != null && value < 0)
                    throw new ArgumentException("EmployeeID must be a non-negative integer.", nameof(EmployeeID));
                m_EmployeeID = value;
            }
        }

        /// <summary>
        /// Gets or sets the unique identifier for the department.
        /// Must be a positive integer.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when the value is <c>null</c> or less than 1.
        /// </exception>
        public int? DepartmentID
        {
            get => m_DepartmentID;
            set
            {
                if (value == null || value < 1)
                    throw new ArgumentException("DepartmentID must be a positive integer.", nameof(DepartmentID));
                m_DepartmentID = value;
            }
        }

        /// <summary>
        /// Gets or sets the first name of the employee.
        /// Cannot be null or empty.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when the value is null or empty.
        /// </exception>
        public string? FirstName
        {
            get => m_FirstName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("FirstName cannot be null or empty.", nameof(FirstName));
                m_FirstName = value;
            }
        }

        /// <summary>
        /// Gets or sets the last name of the employee.
        /// Cannot be null or empty.
        /// </summary>
        /// <example>
        /// <code>
        /// var employee = new Employee(1, "John", "Doe", 25.0);
        /// employee.LastName = "Smith";
        /// </code>
        /// </example>
        /// <exception cref="ArgumentException">
        /// Thrown when the value is null or empty.
        /// </exception>
        public string? LastName
        {
            get => m_LastName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("LastName cannot be null or empty.", nameof(LastName));
                m_LastName = value;
            }
        }

        /// <summary>
        /// Gets or sets the hourly rate for the employee.
        /// Must be a non-negative number.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when the value is null or negative.
        /// </exception>
        public double? HourlyRate
        {
            get => m_HourlyRate;
            set
            {
                if (value == null || value < 0)
                    throw new ArgumentException("HourlyRate must be a non-negative number.", nameof(HourlyRate));
                m_HourlyRate = value;
            }
        }
    }
}