<template>
  <div :class="$style.wrap">
    <div v-if="loading" :class="$style.loading">Loading&hellip;</div>
    <div v-else :class="$style.days">
      <div v-for="day in forecast" :key="day.dateFormatted" :class="$style.day">
        <div :class="$style.temperature">{{ day.temperatureC }}&deg;</div>
        <div :class="$style.summary">{{ day.summary }}</div>
        <div :class="$style.date">{{ day.dateFormatted }}</div>
      </div>
    </div>
  </div>
</template>

<script>
import { onMounted, ref } from 'vue'
export default {
  setup() {
    const loading = ref(false)
    const forecast = ref()

    onMounted(async () => {
      loading.value = true
      const response = await fetch('api/SampleData/WeatherForecasts')
      forecast.value = await response.json()
      loading.value = false
    })

    return { loading, forecast }
  }
}
</script>

<style module>
.wrap {
  display: flex;
  justify-content: center;
  height: 160px;
}
.loading {
  flex: 1px;
  display: flex;
  flex-direction: column;
  justify-content: center;
  font-size: 200%;
  color: silver;
  font-style: oblique;
  animation: blinker 1s linear infinite;
}

@keyframes blinker {
  50% {
    opacity: 0;
  }
}

.days {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}
.day {
  border: 2px solid lightblue;
  border-radius: 16px;
  padding: 10px;
  margin: 10px;
  width: 6em;
  display: flex;
  flex-direction: column;
  justify-content: space-evenly;
}
.summary {
  font-weight: bold;
}
.temperature {
  font-size: 200%;
  font-weight: bold;
}
.date {
  font-size: 80%;
  margin-top: 10px;
}
</style>
