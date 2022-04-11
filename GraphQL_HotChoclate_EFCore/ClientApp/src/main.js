import { createApp, h } from "vue";
import App from "./App.vue";
import router from "./router";
import { ApolloClient, InMemoryCache } from "@apollo/client/core";
import { createApolloProvider } from "@vue/apollo-option";
import VueApolloComponents from "@vue/apollo-components";

const cache = new InMemoryCache();

const apolloClient = new ApolloClient({
  cache,
  uri: "https://localhost:44330/api2",
});

const apolloProvider = createApolloProvider({
  defaultClient: apolloClient,
});

const app = createApp({
  render: () => h(App),
});

app.use(router);
app.use(apolloProvider);
app.use(VueApolloComponents);

app.mount("#app");
