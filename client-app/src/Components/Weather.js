const Weather = ({ weather }) => {
    return (
        <p>
            {weather.date} - {weather.temperatureF}
        </p>
    )
}

export default Weather;