namespace Application.Dto
{
    public enum RoverCommand
    {
        /// <summary>
        /// Move the orver forward by one position.<br/>
        /// </summary>
        F,

        /// <summary>
        /// Move the orver backwards by one position.<br/>
        /// </summary>
        B,

        /// <summary>
        /// Spin the rover to left, keeping same position.<br/>
        /// </summary>
        L,

        /// <summary>
        /// Spin the rover to right, keeping same position.<br/>
        /// </summary>
        R
    }
}
