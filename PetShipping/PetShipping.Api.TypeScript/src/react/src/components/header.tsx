import * as React from 'react';
import { Layout, Menu, Breadcrumb, Icon } from 'antd';
import MenuItem from '../../node_modules/antd/lib/menu/MenuItem';
import { Link, RouteComponentProps } from 'react-router-dom';
import { ClientRoutes, Constants } from '../constants';
const { Header, Content, Footer, Sider } = Layout;

const SubMenu = Menu.SubMenu;

interface WrapperHeaderProps {}

interface WrapperHeaderState {
  collapsed: boolean;
}
export const wrapperHeader = (
  Component: React.ComponentClass<any> | React.SFC<any>,
  displayName: string
) => {
  class WrapperHeaderComponent extends React.Component<
    WrapperHeaderProps & RouteComponentProps,
    WrapperHeaderState
  > {
    state = { collapsed: true };

    onCollapse = () => {
      this.setState({ ...this.state, collapsed: !this.state.collapsed });
    };
    render() {
      return (
        <Layout style={{ minHeight: '100vh' }}>
          <Sider
            collapsible
            collapsed={this.state.collapsed}
            onCollapse={this.onCollapse}
          >
            <div className="logo" />
            <Menu theme="dark" defaultSelectedKeys={['1']} mode="inline">
              <MenuItem
                key="Home"
                onClick={() => {
                  this.setState({ ...this.state, collapsed: true });
                }}
              >
                <Icon type="home" />
                <span>Home</span>
                <Link to={'/'} />
              </MenuItem>

              <MenuItem key="airline">
                <Icon type="pie-chart" />
                <span>Airlines</span>
                <Link to={ClientRoutes.Airlines} />
              </MenuItem>

              <MenuItem key="airTransport">
                <Icon type="rise" />
                <span>AirTransports</span>
                <Link to={ClientRoutes.AirTransports} />
              </MenuItem>

              <MenuItem key="breed">
                <Icon type="bars" />
                <span>Breeds</span>
                <Link to={ClientRoutes.Breeds} />
              </MenuItem>

              <MenuItem key="country">
                <Icon type="cloud" />
                <span>Countries</span>
                <Link to={ClientRoutes.Countries} />
              </MenuItem>

              <MenuItem key="countryRequirement">
                <Icon type="code" />
                <span>CountryRequirements</span>
                <Link to={ClientRoutes.CountryRequirements} />
              </MenuItem>

              <MenuItem key="customer">
                <Icon type="smile" />
                <span>Customers</span>
                <Link to={ClientRoutes.Customers} />
              </MenuItem>

              <MenuItem key="customerCommunication">
                <Icon type="laptop" />
                <span>CustomerCommunications</span>
                <Link to={ClientRoutes.CustomerCommunications} />
              </MenuItem>

              <MenuItem key="destination">
                <Icon type="mobile" />
                <span>Destinations</span>
                <Link to={ClientRoutes.Destinations} />
              </MenuItem>

              <MenuItem key="employee">
                <Icon type="paper-clip" />
                <span>Employees</span>
                <Link to={ClientRoutes.Employees} />
              </MenuItem>

              <MenuItem key="handler">
                <Icon type="setting" />
                <span>Handlers</span>
                <Link to={ClientRoutes.Handlers} />
              </MenuItem>

              <MenuItem key="handlerPipelineStep">
                <Icon type="user" />
                <span>HandlerPipelineSteps</span>
                <Link to={ClientRoutes.HandlerPipelineSteps} />
              </MenuItem>

              <MenuItem key="otherTransport">
                <Icon type="home" />
                <span>OtherTransports</span>
                <Link to={ClientRoutes.OtherTransports} />
              </MenuItem>

              <MenuItem key="pet">
                <Icon type="camera" />
                <span>Pets</span>
                <Link to={ClientRoutes.Pets} />
              </MenuItem>

              <MenuItem key="pipeline">
                <Icon type="like" />
                <span>Pipelines</span>
                <Link to={ClientRoutes.Pipelines} />
              </MenuItem>

              <MenuItem key="pipelineStatus">
                <Icon type="bulb" />
                <span>PipelineStatus</span>
                <Link to={ClientRoutes.PipelineStatus} />
              </MenuItem>

              <MenuItem key="pipelineStep">
                <Icon type="tool" />
                <span>PipelineSteps</span>
                <Link to={ClientRoutes.PipelineSteps} />
              </MenuItem>

              <MenuItem key="pipelineStepDestination">
                <Icon type="coffee" />
                <span>PipelineStepDestinations</span>
                <Link to={ClientRoutes.PipelineStepDestinations} />
              </MenuItem>

              <MenuItem key="pipelineStepNote">
                <Icon type="experiment" />
                <span>PipelineStepNotes</span>
                <Link to={ClientRoutes.PipelineStepNotes} />
              </MenuItem>

              <MenuItem key="pipelineStepStatus">
                <Icon type="security-scan" />
                <span>PipelineStepStatus</span>
                <Link to={ClientRoutes.PipelineStepStatus} />
              </MenuItem>

              <MenuItem key="pipelineStepStepRequirement">
                <Icon type="thunderbolt" />
                <span>PipelineStepStepRequirements</span>
                <Link to={ClientRoutes.PipelineStepStepRequirements} />
              </MenuItem>

              <MenuItem key="sale">
                <Icon type="gateway" />
                <span>Sales</span>
                <Link to={ClientRoutes.Sales} />
              </MenuItem>

              <MenuItem key="species">
                <Icon type="shopping" />
                <span>Species</span>
                <Link to={ClientRoutes.Species} />
              </MenuItem>
            </Menu>
          </Sider>
          <Layout>
            <Header style={{ background: '#fff', padding: 0 }} />
            <Content style={{ margin: '0 16px' }}>
              <h2>{displayName}</h2>
              <div style={{ padding: 24, background: '#fff', minHeight: 360 }}>
                <Component {...this.props} />
              </div>
            </Content>
            <Footer style={{ textAlign: 'center' }}>Footer</Footer>
          </Layout>
        </Layout>
      );
    }
  }
  return WrapperHeaderComponent;
};


/*<Codenesium>
    <Hash>d9934cddf7fda2053d4ac23a7914614a</Hash>
</Codenesium>*/