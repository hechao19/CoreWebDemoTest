﻿var pager = {
    props:
    {
        pagerData: {
            type: Object,
            default: function () {
                return {
                    isShow: true,
                    //分页大小
                    pageSize: 10,
                    //分页数
                    arrPageSize: [10, 20, 30, 40],
                    //当前页面
                    pageCurrent: 1,
                    //总分页数
                    pageCount: 1,
                    //总数
                    totalCount: 10
                }
            }
        }
    },
    //html模板内容
    template: '<div v-if="pagerData.isShow">\
				    <div class="pager" id="pager">\
                </div>',
    data: function () {
        return {
            mypagesize: 10,
            mypageCurrent: 1
        }
    },
    //计算属性
    computed: {
        // 分页大小 获取的时候显示父级传入的，修改的时候修改自身的。子组件不能修改父元素的值
        pageSize: {
            get: function () {
                return this.pagerData.pageSize;
            },
            set: function (value) {
                this.mypagesize = value;
            }
        },
        pageCurrent: {
            get: function () {
                return this.pagerData.pageCurrent;
            },
            set: function (value) {
                this.mypageCurrent = value;
            }
        },
        startData: function () {
            return this.pagerData.pageSize * (this.pagerData.pageCurrent - 1) + 1;
        },
        endData: function () {
            var max = this.pagerData.pageSize * this.pagerData.pageCurrent;
            return max > this.pagerData.totalCount ? this.pagerData.totalCount : max;
        }
    },
    methods: {
        showPage: function (pageIndex) {
            if (pageIndex > 0) {
                if (pageIndex > this.pagerData.pageCount) pageIndex = this.pagerData.pageCount;
                this.$emit('show-page', { pageCurrent: pageIndex, pageSize: this.mypagesize });//事件
                                
            }
        }
    }
}