<template>
  <div class="about">
    <!-- Get list of Employees -->
    <h1>{{ test1 }}</h1>
    <ApolloQuery
      :query="
        (gql) => gql`
          query {
            employees {
              id
              name
              designation
            }
          }
        `
      "
    >
      <!-- <ApolloQuery
      :query="require('../graphql/getEmployees.gql')"
      :variables="{}"
    > -->
      <template v-slot="{ result: { loading, error, data } }">
        <!-- Loading -->
        <div v-if="loading" class="loading apollo">Loading...</div>

        <!-- Error -->
        <div v-else-if="error" class="error apollo">An error occurred</div>

        <!-- Result -->
        <div v-else-if="data" class="result apollo">
          <div v-for="item in data.employees" :key="item">
            {{ item.id }} {{ item.name }} {{ item.designation }}
          </div>
        </div>

        <!-- No result -->
        <div v-else class="no-result apollo">-</div>
      </template>
    </ApolloQuery>
    <!-- Get single emplyoee -->
    <!-- <h1>{{ test4 }}</h1>
    <ApolloQuery
      :query="
        (gql) => gql`
          query employee($id: Int!) {
            employee(id: $id) {
              id
              name
              designation
            }
          }
        `
      "
      :variables="{ id: getId }"
    >
      <template v-slot="{ result: { loading, error, data } }">
        <input type="number" v-model="getId" />
        <button :disabled="loading" @click="this.$apollo.query()">
          Get Employee
        </button>
        <div v-if="loading" class="loading apollo">Loading...</div>
        <div v-else-if="error" class="error apollo">An error occurred</div>
        <div v-else-if="data" class="result apollo">
          <div>
            Employee({{ getId }})): {{ data.id }} {{ data.name }}
            {{ data.designation }}
          </div>
        </div>
        <div v-else class="no-result apollo">-</div>
      </template>
    </ApolloQuery> -->
    <!-- Create an Employee -->
    <h1>{{ test2 }}</h1>
    <ApolloMutation
      :mutation="
        (gql) => gql`
          mutation create($id: Int!, $name: String!, $designation: String!) {
            create(id: $id, name: $name, designation: $designation) {
              id
              name
              designation
            }
          }
        `
      "
      :variables="{ id: 0, name: name, designation: designation }"
      @done="onDoneCreate"
    >
      <template v-slot="{ mutate, loading, error, data }">
        <input type="text" v-model="name" placeholder="name" />
        <input type="text" v-model="designation" placeholder="designation" />
        <button :disabled="loading" @click="mutate()">Create Employee</button>
        <div>
          Employee name is <b>{{ name }}</b> and designation is
          <b>{{ designation }}</b>
        </div>
        <p v-if="error">An error occurred: {{ error }}</p>
        <p v-else>{{ data }}</p>
      </template>
    </ApolloMutation>
    <h1>{{ test3 }}</h1>
    <ApolloMutation
      :mutation="
        (gql) => gql`
          mutation delete($id: Int!) {
            delete(id: $id) {
              id
              name
              designation
            }
          }
        `
      "
      :variables="{ id: deleteId }"
      @done="onDoneDelete"
    >
      <template v-slot="{ mutate, loading, error, data }">
        <input type="number" v-model="deleteId" />
        <button :disabled="loading" @click="mutate()">Delete Employee</button>
        <div>deleted item Id: {{ deleteId }}</div>
        <p v-if="error">An error occurred: {{ error }}</p>
        <p v-else>{{ data }}</p>
      </template>
    </ApolloMutation>
  </div>
</template>

<script>
export default {
  data() {
    return {
      name: "",
      designation: "",
      getId: 0,
      deleteId: 0,
      test1: "Query by Component list employees: ",
      test2: "Mutation by Component create employee: ",
      test3: "Mutation by Component delete employee: ",
      test4: "Query by Component single employee: ",
    };
  },
};
</script>
