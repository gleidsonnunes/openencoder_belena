(window["webpackJsonp"] = window["webpackJsonp"] || []).push([
    ["status"], {
        9989: function (t, e, s) {
            "use strict";
            s.r(e);
            var a, n, r, c = function () {
                var t = this,
                    e = t.$createElement,
                    s = t._self._c || e;
                return s("div", {
                    staticClass: "container",
                    attrs: {
                        id: "status"
                    }
                }, [s("Status")], 1)
            },
                i = [],
                l = function () {
                    var t = this,
                        e = t.$createElement,
                        s = t._self._c || e;
                    return s("div", {
                        staticClass: "status container"
                    }, [s("h2", {
                        staticClass: "text-muted"
                    }, [t._v("Jobs")]), s("b-card-group", {
                        attrs: {
                            deck: ""
                        }
                    }, t._l(t.stats.jobs, (function (e, a) {
                        return s("div", {
                            key: a,
                            staticClass: "col-lg-4 col-md-4 p-1 mb-2"
                        }, [s("b-card", {
                            staticClass: "text-center",
                            attrs: {
                                "border-variant": t.getStatusColor(e.status),
                                header: e.status.toUpperCase()
                            }
                        }, [s("b-card-text", [t._v(t._s(e.count))])], 1)], 1)
                    })), 0), s("hr"), s("h2", {
                        staticClass: "text-muted"
                    }, [t._v("Health")]), s("b-card-group", {
                        attrs: {
                            deck: ""
                        }
                    }, t._l(t.health, (function (e, a) {
                        return s("div", {
                            key: a,
                            staticClass: "col-lg-3 col-md-3 p-1 mb-2"
                        }, [s("b-card", {
                            staticClass: "text-center",
                            attrs: {
                                header: a.toUpperCase()
                            }
                        }, [s("b-card-text", [s("b-alert", {
                            attrs: {
                                show: "",
                                variant: ["NOTOK", 0].includes(e) ? "danger" : "success"
                            }
                        }, [t._v(t._s(e))])], 1)], 1)], 1)
                    })), 0), s("hr"), s("h2", {
                        staticClass: "text-muted"
                    }, [t._v("Machines")]), s("b-card-group", {
                        attrs: {
                            deck: ""
                        }
                    }, t._l(t.pricing, (function (e, a) {
                        return s("div", {
                            key: a,
                            staticClass: "col-lg-4 col-md-4 p-1 mb-2"
                        }, [s("b-card", {
                            staticClass: "text-center",
                            attrs: {
                                header: a.toUpperCase()
                            }
                        }, [s("b-card-text", [s("b-alert", {
                            attrs: {
                                show: ""
                            }
                        }, [t._v(t._s(e))])], 1)], 1)], 1)
                    })), 0), 0 === Object.keys(t.pricing).length ? s("h2", {
                        staticClass: "text-center"
                    }, [t._v("No Machines Running")]) : t._e(), t.stats.jobs ? t._e() : s("h2", {
                        staticClass: "text-center"
                    }, [t._v("No Stats Found")])], 1)
                },
                o = [],
                u = s("d722"),
                d = 5e3,
                h = 1e4,
                g = 3e4,
                p = {
                    name: "status",
                    data: function () {
                        return {
                            stats: {},
                            health: {},
                            pricing: {}
                        }
                    },
                    mounted: function () {
                        this.getStats(), this.getHealth(), this.getPricing(), a = setInterval(this.getStats, d), n = setInterval(this.getHealth, h), r = setInterval(this.getPricing, g)
                    },
                    destroyed: function () {
                        clearInterval(a), clearInterval(n), clearInterval(r)
                    },
                    methods: {
                        getStatusColor: function (t) {
                            var e = {
                                queued: "primary",
                                completed: "success",
                                downloading: "warning",
                                encoding: "info",
                                uploading: "warning",
                                error: "danger"
                            };
                            return e[t] || "secondary"
                        },
                        getStats: function () {
                            var t = this;
                            u["a"].getStats(this, (function (e, s) {
                                s.stats && (t.stats = s.stats)
                            }))
                        },
                        getHealth: function () {
                            var t = this;
                            u["a"].getHealth(this, (function (e, s) {
                                s && (t.health = s)
                            }))
                        },
                        getPricing: function () {
                            var t = this;
                            u["a"].getPricing(this, (function (e, s) {
                                e ? console.log(e) : s.pricing && (t.pricing = s.pricing)
                            }))
                        }
                    }
                },
                v = p,
                b = s("2877"),
                f = Object(b["a"])(v, l, o, !1, null, null, null),
                _ = f.exports,
                m = {
                    name: "status",
                    components: {
                        Status: _
                    }
                },
                C = m,
                x = Object(b["a"])(C, c, i, !1, null, null, null);
            e["default"] = x.exports
        }
    }
]);
//# sourceMappingURL=status.a1caed0e.js.map