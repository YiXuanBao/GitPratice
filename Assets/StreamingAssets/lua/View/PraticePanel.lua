local transform;
local gameObject;

PraticePanel = {};
local this = PraticePanel;

--启动事件--
function PraticePanel.Awake(obj)
	gameObject = obj;
	transform = obj.transform;

	this.InitPanel();
	logWarn("Awake lua--->>"..gameObject.name);
end

--初始化面板--
function PraticePanel.InitPanel()
	this.btnOpen = transform:Find("Open").gameObject;
	this.gridParent = transform:Find('ScrollView/Grid');
end

--单击事件--
function PraticePanel.OnDestroy()
	logWarn("PraticePanel OnDestroy---->>>");
end