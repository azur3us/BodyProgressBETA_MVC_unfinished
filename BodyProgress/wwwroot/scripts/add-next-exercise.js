const newItem = () => ({
    exerciseId: null,
    weight: 0,
    reps: 0
});
new Vue({
    el: '#create-training',
    data() {
        return {
            planItems: [newItem()]
        }
    },
    methods: {
        addNext() {
            this.planItems.push(newItem())
        }
    }
})