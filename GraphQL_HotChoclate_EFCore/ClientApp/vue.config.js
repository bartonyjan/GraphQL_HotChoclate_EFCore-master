module.exports = {
  devServer: {
    disableHostCheck: true,
    proxy: {
      '^/api/': {
        target: 'http://localhost:5000/'
      }
    }
  },

  /**
   * @see https://cli.vuejs.org/config/#productionsourcemap
   */
  productionSourceMap: process.env.NODE_ENV != 'production',

  /**
   * Load all files as modules by default, needed for scss files
   * (no needs to add '.module.scss' into the the filenames)
   * @see https://cli.vuejs.org/config/#css-requiremoduleextension
   */
  css: {
    requireModuleExtension: false
  },
}
