(function (e) {
    function t(t) {
        for (var r, o, a = t[0], c = t[1], u = t[2], l = 0, f = []; l < a.length; l++) o = a[l], Object.prototype.hasOwnProperty.call(s, o) && s[o] && f.push(s[o][0]), s[o] = 0;
        for (r in c) Object.prototype.hasOwnProperty.call(c, r) && (e[r] = c[r]);
        d && d(t);
        while (f.length) f.shift()();
        return i.push.apply(i, u || []), n()
    }

    function n() {
        for (var e, t = 0; t < i.length; t++) {
            for (var n = i[t], r = !0, o = 1; o < n.length; o++) {
                var a = n[o];
                0 !== s[a] && (r = !1)
            }
            r && (i.splice(t--, 1), e = c(c.s = n[0]))
        }
        return e
    }
    var r = {},
        o = {
            app: 0
        },
        s = {
            app: 0
        },
        i = [];

    function a(e) {
        return c.p + "js/" + ({
            encode: "encode",
            jobs: "jobs",
            "machines~presets~settings": "machines~presets~settings",
            machines: "machines",
            presets: "presets",
            settings: "settings",
            queue: "queue",
            status: "status",
            workers: "workers"
        }[e] || e) + "." + {
            encode: "15ce5463",
            jobs: "c8ae645b",
            "machines~presets~settings": "c04a9be4",
            machines: "93b7fee7",
            presets: "d32bdb64",
            settings: "fe7345a9",
            queue: "40bfb434",
            status: "a1caed0e",
            workers: "eae1317d"
        }[e] + ".js"
    }

    function c(t) {
        if (r[t]) return r[t].exports;
        var n = r[t] = {
            i: t,
            l: !1,
            exports: {}
        };
        return e[t].call(n.exports, n, n.exports, c), n.l = !0, n.exports
    }
    c.e = function (e) {
        var t = [],
            n = {
                jobs: 1,
                machines: 1,
                presets: 1
            };
        o[e] ? t.push(o[e]) : 0 !== o[e] && n[e] && t.push(o[e] = new Promise((function (t, n) {
            for (var r = "css/" + ({
                encode: "encode",
                jobs: "jobs",
                "machines~presets~settings": "machines~presets~settings",
                machines: "machines",
                presets: "presets",
                settings: "settings",
                queue: "queue",
                status: "status",
                workers: "workers"
            }[e] || e) + "." + {
                encode: "31d6cfe0",
                jobs: "7c44befd",
                "machines~presets~settings": "31d6cfe0",
                machines: "1e3eb5a1",
                presets: "3890ffb2",
                settings: "31d6cfe0",
                queue: "31d6cfe0",
                status: "31d6cfe0",
                workers: "31d6cfe0"
            }[e] + ".css", s = c.p + r, i = document.getElementsByTagName("link"), a = 0; a < i.length; a++) {
                var u = i[a],
                    l = u.getAttribute("data-href") || u.getAttribute("href");
                if ("stylesheet" === u.rel && (l === r || l === s)) return t()
            }
            var f = document.getElementsByTagName("style");
            for (a = 0; a < f.length; a++) {
                u = f[a], l = u.getAttribute("data-href");
                if (l === r || l === s) return t()
            }
            var d = document.createElement("link");
            d.rel = "stylesheet", d.type = "text/css", d.onload = t, d.onerror = function (t) {
                var r = t && t.target && t.target.src || s,
                    i = new Error("Loading CSS chunk " + e + " failed.\n(" + r + ")");
                i.code = "CSS_CHUNK_LOAD_FAILED", i.request = r, delete o[e], d.parentNode.removeChild(d), n(i)
            }, d.href = s;
            var h = document.getElementsByTagName("head")[0];
            h.appendChild(d)
        })).then((function () {
            o[e] = 0
        })));
        var r = s[e];
        if (0 !== r)
            if (r) t.push(r[2]);
            else {
                var i = new Promise((function (t, n) {
                    r = s[e] = [t, n]
                }));
                t.push(r[2] = i);
                var u, l = document.createElement("script");
                l.charset = "utf-8", l.timeout = 120, c.nc && l.setAttribute("nonce", c.nc), l.src = a(e);
                var f = new Error;
                u = function (t) {
                    l.onerror = l.onload = null, clearTimeout(d);
                    var n = s[e];
                    if (0 !== n) {
                        if (n) {
                            var r = t && ("load" === t.type ? "missing" : t.type),
                                o = t && t.target && t.target.src;
                            f.message = "Loading chunk " + e + " failed.\n(" + r + ": " + o + ")", f.name = "ChunkLoadError", f.type = r, f.request = o, n[1](f)
                        }
                        s[e] = void 0
                    }
                };
                var d = setTimeout((function () {
                    u({
                        type: "timeout",
                        target: l
                    })
                }), 12e4);
                l.onerror = l.onload = u, document.head.appendChild(l)
            } return Promise.all(t)
    }, c.m = e, c.c = r, c.d = function (e, t, n) {
        c.o(e, t) || Object.defineProperty(e, t, {
            enumerable: !0,
            get: n
        })
    }, c.r = function (e) {
        "undefined" !== typeof Symbol && Symbol.toStringTag && Object.defineProperty(e, Symbol.toStringTag, {
            value: "Module"
        }), Object.defineProperty(e, "__esModule", {
            value: !0
        })
    }, c.t = function (e, t) {
        if (1 & t && (e = c(e)), 8 & t) return e;
        if (4 & t && "object" === typeof e && e && e.__esModule) return e;
        var n = Object.create(null);
        if (c.r(n), Object.defineProperty(n, "default", {
            enumerable: !0,
            value: e
        }), 2 & t && "string" != typeof e)
            for (var r in e) c.d(n, r, function (t) {
                return e[t]
            }.bind(null, r));
        return n
    }, c.n = function (e) {
        var t = e && e.__esModule ? function () {
            return e["default"]
        } : function () {
            return e
        };
        return c.d(t, "a", t), t
    }, c.o = function (e, t) {
        return Object.prototype.hasOwnProperty.call(e, t)
    }, c.p = "/dashboard/", c.oe = function (e) {
        throw console.error(e), e
    };
    var u = window["webpackJsonp"] = window["webpackJsonp"] || [],
        l = u.push.bind(u);
    u.push = t, u = u.slice();
    for (var f = 0; f < u.length; f++) t(u[f]);
    var d = l;
    i.push([0, "chunk-vendors"]), n()
})({
    0: function (e, t, n) {
        e.exports = n("56d7")
    },
    1: function (e, t) { },
    "1ab6": function (e, t, n) {
        "use strict";
        n("b0c0");
        var r = n("04e1"),
            o = n.n(r),
            s = n("44c2"),
            i = {
                state: {
                    token: null
                },
                setTokenAction: function (e) {
                    this.state.token = e
                }
            },
            a = "/api/login";
        t["a"] = {
            user: {
                username: null,
                role: null,
                authenticated: !1
            },
            login: function (e, t, n, r) {
                var c = this;
                e.$http.post(a, t).then((function (t) {
                    s["a"].set("token", t.body.token), i.setTokenAction(t.body.token), c.user.authenticated = !0, c.user.username = o()(t.body.token).id, n && (e.$router.push({
                        name: n
                    }), e.$router.go())
                }), (function (e) {
                    r(e)
                }))
            },
            logout: function (e) {
                s["a"].remove("token"), this.user.authenticated = !1, window.location.href = "/MicrosoftIdentity/Account/SignOut/OpenIdConnect"
            },
            checkAuth: function (e) {
                var t = s["a"].get("token");
                t && !this.isExpired(t) ? (i.setTokenAction(t), this.user.authenticated = !0, this.user.username = o()(t).id, this.user.role = o()(t).role) : "login" !== e.$route.name && e.$router.push({
                    name: "login"
                })
            },
            isExpired: function (e) {
                return Date.now() >= 1e3 * o()(e).exp
            },
            getAuthHeader: function () {
                return {
                    Authorization: "Bearer ".concat(i.state.token)
                }
            }
        }
    },
    "3a51": function (e, t, n) {
        "use strict";
        var r = n("e434"),
            o = n.n(r);
        o.a
    },
    "44c2": function (e, t, n) {
        "use strict";
        var r = n("a78e"),
            o = n.n(r);
        t["a"] = {
            set: function (e, t) {
                var n = {
                    expires: 7
                };
                o.a.set(e, t, n)
            },
            get: function (e) {
                return o.a.get(e)
            },
            remove: function (e) {
                o.a.remove(e)
            }
        }
    },
    "56d7": function (e, t, n) {
        "use strict";
        n.r(t);
        n("e623"), n("e379"), n("5dc8"), n("37e1");
        var r, o, s = n("2b0e"),
            i = function () {
                var e = this,
                    t = e.$createElement,
                    n = e._self._c || t;
                return n("div", {
                    attrs: {
                        id: "app"
                    }
                }, [n("b-navbar", {
                    staticClass: "mb-4",
                    attrs: {
                        toggleable: "lg",
                        type: "dark",
                        variant: "dark"
                    }
                }, [n("b-navbar-brand", {
                    attrs: {
                        href: "#"
                    }
                }, [e._v("Open Encoder "), n("sup", {
                    staticClass: "alpha"
                }, [e._v(e._s(e.version))])]), n("b-navbar-toggle", {
                    attrs: {
                        target: "nav-collapse"
                    }
                }), n("b-navbar-nav", {
                    staticClass: "ml-auto"
                }, [e.user.authenticated ? n("b-nav-item-dropdown", {
                    attrs: {
                        right: ""
                    }
                }, [n("template", {
                    slot: "button-content"
                }, [e._v(e._s(e.user.username))]), n("b-dropdown-item", {
                    attrs: {
                        disabled: ""
                    }
                }, [e._v(e._s(e.user.role))]), n("b-dropdown-item", {
                    attrs: {
                        href: "#"
                    },
                    on: {
                        click: e.logout
                    }
                }, [e._v("Sign Out")])], 2) : e._e()], 1)], 1), e.$route.meta.hideNavigation ? e._e() : n("div", {
                    staticClass: "container mb-4"
                }, [n("b-nav", {
                    attrs: {
                        tabs: ""
                    }
                }, [n("b-nav-item", {
                    attrs: {
                        to: "/status"
                    }
                }, [e._v("Status")]), n("b-nav-item", {
                    attrs: {
                        to: "/jobs"
                    }
                }, [e._v("Jobs")]), e.isOperatorAdmin ? n("b-nav-item", {
                    attrs: {
                        to: "/encode"
                    }
                }, [e._v("Encode")]) : e._e(), e.isOperatorAdmin ? n("b-nav-item", {
                    attrs: {
                        to: "/queue"
                    }
                }, [e._v("Queue")]) : e._e(), e.isOperatorAdmin ? n("b-nav-item", {
                    attrs: {
                        to: "/workers"
                    }
                }, [e._v("Workers")]) : e._e(), e.isAdmin ? n("b-nav-item", {
                    attrs: {
                        to: "/machines"
                    }
                }, [e._v("Machines")]) : e._e(), e.isAdmin ? n("b-nav-item", {
                    attrs: {
                        to: "/presets"
                    }
                }, [e._v("Presets")]) : e._e(), e.isAdmin ? n("b-nav-item", {
                    attrs: {
                        to: "/settings"
                    }
                }, [e._v("Settings")]) : e._e()], 1)], 1), n("router-view"), n("footer", {
                    staticClass: "container mt-4 text-center"
                }, [n("hr"), n("div", {
                    staticClass: "text-muted"
                }, [n("ul", [e._m(0), e._m(1), e._m(2), e._m(3), n("li", [e._v(e._s(e.version))])])])])], 1)
            },
            a = [function () {
                var e = this,
                    t = e.$createElement,
                    n = e._self._c || t;
                return n("li", [n("a", {
                    attrs: {
                        href: "https://github.com/alfg/openencoder"
                    }
                }, [e._v("Docs")])])
            }, function () {
                var e = this,
                    t = e.$createElement,
                    n = e._self._c || t;
                return n("li", [n("a", {
                    attrs: {
                        href: "https://github.com/alfg/openencoder/blob/master/API.md"
                    }
                }, [e._v("API")])])
            }, function () {
                var e = this,
                    t = e.$createElement,
                    n = e._self._c || t;
                return n("li", [n("a", {
                    attrs: {
                        href: "https://github.com/alfg/openencoder/wiki"
                    }
                }, [e._v("Wiki")])])
            }, function () {
                var e = this,
                    t = e.$createElement,
                    n = e._self._c || t;
                return n("li", [n("a", {
                    attrs: {
                        href: "https://github.com/alfg/openencoder"
                    }
                }, [e._v("Source")])])
            }],
            c = (n("99af"), n("b0c0"), n("1ab6")),
            u = n("d722"),
            l = {
                data: function () {
                    return {
                        user: c["a"].user,
                        role: c["a"].role,
                        version: null
                    }
                },
                computed: {
                    isOperator: function () {
                        return !0
                    },
                    isAdmin: function () {
                        return !0
                    },
                    isOperatorAdmin: function () {
                        return !0
                    }
                },
                created: function () {
                    c["a"].checkAuth(this), this.getVersion()
                },
                methods: {
                    getVersion: function () {
                        var e = this;
                        u["a"].getVersion(this, (function (t, n) {
                            if (n.version) {
                                var r = n.name,
                                    o = n.version;
                                e.version = "".concat(r, "-").concat(o)
                            }
                        }))
                    },
                    logout: function () {
                        c["a"].logout(this)
                    }
                }
            },
            f = l,
            d = (n("3a51"), n("2877")),
            h = Object(d["a"])(f, i, a, !1, null, "0dd7997d", null),
            p = h.exports,
            m = (n("d3b7"), n("8c4f")),
            g = n("28dd"),
            b = n("2ead"),
            v = n.n(b),
            _ = n("5f5b"),
            k = function () {
                var e = this,
                    t = e.$createElement,
                    n = e._self._c || t;
                return n("div", {
                    staticClass: "container col-lg-4 col-md-4",
                    attrs: {
                        id: "login"
                    }
                }, [n("LoginForm")], 1)
            },
            w = [],
            y = {
                components: {},
                data: function () {
                    return {
                        form: {
                            username: "",
                            password: ""
                        },
                        show: !0,
                        dismissSecs: 5,
                        dismissCountDown: 0,
                        showDismissibleAlert: !1,
                        errorMessage: ""
                    }
                },
                methods: {
                    countDownChanged: function (e) {
                        this.dismissCountDown = e
                    },
                    onSubmit: function () {
                        var e = this;
                        c["a"].login(this, null, "/", (function (t) {
                            t && (e.errorMessage = t.body && t.body.message, e.dismissCountDown = e.dismissSecs)
                        }))
                    }
                },
                beforeMount: function () {
                    this.onSubmit()
                }
            },
            j = y,
            A = Object(d["a"])(j, r, o, !1, null, null, null),
            P = A.exports,
            C = {
                name: "login",
                components: {
                    LoginForm: P
                }
            },
            S = C,
            M = Object(d["a"])(S, k, w, !1, null, null, null),
            O = M.exports,
            E = n("44c2");
        n("f9e3"), n("2dd8");
        s["default"].use(m["a"]), s["default"].use(_["a"]), s["default"].use(g["a"]), s["default"].use(v.a), s["default"].http.headers.common.Authorization = "Bearer ".concat(E["a"].get("token"));
        var $ = new m["a"]({
            mode: "history",
            base: "/dashboard/",
            routes: [{
                path: "/",
                redirect: "/status"
            }, {
                path: "/status",
                name: "home",
                component: function () {
                    return n.e("status").then(n.bind(null, "9989"))
                }
            }, {
                path: "/jobs",
                name: "jobs",
                component: function () {
                    return n.e("jobs").then(n.bind(null, "ee68"))
                }
            }, {
                path: "/encode",
                name: "encode",
                component: function () {
                    return n.e("encode").then(n.bind(null, "358f"))
                }
            }, {
                path: "/queue",
                name: "queue",
                component: function () {
                    return n.e("queue").then(n.bind(null, "9b31"))
                }
            }, {
                path: "/workers",
                name: "workers",
                component: function () {
                    return n.e("workers").then(n.bind(null, "0996"))
                }
            }, {
                path: "/machines",
                name: "machines",
                component: function () {
                    return Promise.all([n.e("machines~presets~settings"), n.e("machines")]).then(n.bind(null, "0e9b"))
                }
            }, {
                path: "/presets",
                name: "presets",
                component: function () {
                    return Promise.all([n.e("machines~presets~settings"), n.e("presets")]).then(n.bind(null, "8a2c"))
                }
            }, {
                path: "/presets/create",
                name: "presets-create",
                component: function () {
                    return Promise.all([n.e("machines~presets~settings"), n.e("presets")]).then(n.bind(null, "1c3a"))
                }
            }, {
                path: "/settings",
                name: "settings",
                component: function () {
                    return Promise.all([n.e("machines~presets~settings"), n.e("settings")]).then(n.bind(null, "26d3"))
                }
            }, {
                path: "/login",
                name: "login",
                component: O,
                meta: {
                    hideNavigation: !0
                }
            }]
        }),
            x = n("9483");
        Object(x["a"])("".concat("/dashboard/", "service-worker.js"), {
            ready: function () {
                console.log("App is being served from cache by a service worker.\nFor more details, visit https://goo.gl/AFskqB")
            },
            registered: function () {
                console.log("Service worker has been registered.")
            },
            cached: function () {
                console.log("Content has been cached for offline use.")
            },
            updatefound: function () {
                console.log("New content is downloading.")
            },
            updated: function () {
                console.log("New content is available; please refresh.")
            },
            offline: function () {
                console.log("No internet connection found. App is running in offline mode.")
            },
            error: function (e) {
                console.error("Error during service worker registration:", e)
            }
        }), s["default"].config.productionTip = !1, new s["default"]({
            router: $,
            render: function (e) {
                return e(p)
            }
        }).$mount("#app")
    },
    d722: function (e, t, n) {
        "use strict";
        var r = n("1ab6"),
            o = "/api",
            s = {
                Version: "".concat(o, "/"),
                Stats: "".concat(o, "/stats"),
                Health: "".concat(o, "/health"),
                Pricing: "".concat(o, "/machines/pricing"),
                JobsList: function (e) {
                    return "".concat(o, "/jobs?page=").concat(e)
                },
                Jobs: "".concat(o, "/jobs"),
                JobsCancel: function (e) {
                    return "".concat(o, "/jobs/").concat(e, "/cancel")
                },
                JobsRestart: function (e) {
                    return "".concat(o, "/jobs/").concat(e, "/restart")
                },
                Machines: "".concat(o, "/machines"),
                MachinesRegions: "".concat(o, "/machines/regions"),
                MachinesSizes: "".concat(o, "/machines/sizes"),
                MachinesVPCs: "".concat(o, "/machines/vpc"),
                MachinesId: function (e) {
                    return "".concat(o, "/machines/").concat(e)
                },
                PresetsList: function (e) {
                    return "".concat(o, "/presets?page=").concat(e)
                },
                Presets: "".concat(o, "/presets"),
                PresetsId: function (e) {
                    return "".concat(o, "/presets/").concat(e)
                },
                FileList: function (e) {
                    return "".concat(o, "/storage/list?prefix=").concat(e)
                },
                WorkerQueue: "".concat(o, "/worker/queue"),
                WorkerPools: "".concat(o, "/worker/pools"),
                Users: "".concat(o, "/users"),
                UsersId: function (e) {
                    return "".concat(o, "/users/").concat(e)
                },
                Settings: "".concat(o, "/settings"),
                CurrentUser: "".concat(o, "/me")
            };

        function i(e, t, n) {
            e.$http.get(t, {
                headers: r["a"].getAuthHeader()
            }).then((function (e) {
                return e.json()
            })).then((function (e) {
                n(null, e)
            })).catch((function (e) {
                n(e)
            }))
        }

        function a(e, t, n, o) {
            e.$http.post(t, n, {
                headers: r["a"].getAuthHeader()
            }).then((function (e) {
                return e.json()
            })).then((function (e) {
                o(null, e)
            })).catch((function (e) {
                o(e)
            }))
        }

        function c(e, t, n, o) {
            e.$http.put(t, n, {
                headers: r["a"].getAuthHeader()
            }).then((function (e) {
                return e.json()
            })).then((function (e) {
                o(null, e)
            })).catch((function (e) {
                o(e)
            }))
        }

        function u(e, t, n) {
            e.$http.delete(t, {
                headers: r["a"].getAuthHeader()
            }).then((function (e) {
                return e.json()
            })).then((function (e) {
                n(null, e)
            })).catch((function (e) {
                n(e)
            }))
        }
        t["a"] = {
            getVersion: function (e, t) {
                return i(e, s.Version, t)
            },
            getStats: function (e, t) {
                return i(e, s.Stats, t)
            },
            getHealth: function (e, t) {
                return i(e, s.Health, t)
            },
            getPricing: function (e, t) {
                return i(e, s.Pricing, t)
            },
            getJobs: function (e, t, n) {
                return i(e, s.JobsList(t), n)
            },
            createJob: function (e, t, n) {
                return a(e, s.Jobs, t, n)
            },
            cancelJob: function (e, t, n) {
                return a(e, s.JobsCancel(t), {}, n)
            },
            restartJob: function (e, t, n) {
                return a(e, s.JobsRestart(t), {}, n)
            },
            getMachines: function (e, t) {
                return i(e, s.Machines, t)
            },
            getMachineRegions: function (e, t) {
                return i(e, s.MachinesRegions, t)
            },
            getMachineSizes: function (e, t) {
                return i(e, s.MachinesSizes, t)
            },
            getMachineVPCs: function (e, t) {
                return i(e, s.MachinesVPCs, t)
            },
            createMachine: function (e, t, n) {
                return a(e, s.Machines, t, n)
            },
            deleteMachine: function (e, t, n) {
                return u(e, s.MachinesId(t), n)
            },
            deleteAllMachines: function (e, t) {
                return u(e, s.Machines, t)
            },
            getPresets: function (e, t, n) {
                return i(e, s.PresetsList(t), n)
            },
            createPreset: function (e, t, n) {
                return a(e, s.Presets, t, n)
            },
            updatePreset: function (e, t, n) {
                return c(e, s.PresetsId(t.id), t, n)
            },
            getFileList: function (e, t, n) {
                return i(e, s.FileList(t), n)
            },
            getWorkerQueue: function (e, t) {
                return i(e, s.WorkerQueue, t)
            },
            getWorkerPools: function (e, t) {
                return i(e, s.WorkerPools, t)
            },
            getUsers: function (e, t) {
                return i(e, s.Users, t)
            },
            updateUser: function (e, t, n) {
                return c(e, s.UsersId(t.id), t, n)
            },
            getSettings: function (e, t) {
                return i(e, s.Settings, t)
            },
            updateSettings: function (e, t, n) {
                return c(e, s.Settings, t, n)
            },
            getCurrentUser: function (e, t) {
                return i(e, s.CurrentUser, t)
            },
            updateCurrentUser: function (e, t, n) {
                return c(e, s.CurrentUser, t, n)
            }
        }
    },
    e434: function (e, t, n) { }
});
//# sourceMappingURL=app.9c5da2dd.js.map