import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import MachineMapper from './machineMapper';
import MachineViewModel from './machineViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { LinkTableComponent } from '../shared/linkTable';

interface MachineDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface MachineDetailComponentState {
  model?: MachineViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class MachineDetailComponent extends React.Component<
  MachineDetailComponentProps,
  MachineDetailComponentState
> {
  state = {
    model: new MachineViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Machines + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.MachineClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Machines +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new MachineMapper();

        this.setState({
          model: mapper.mapApiResponseToViewModel(response.data),
          loading: false,
          loaded: true,
          errorOccurred: false,
          errorMessage: '',
        });
      })
      .catch((error: AxiosError) => {
        GlobalUtilities.logError(error);

        if (error.response && error.response.status == 422) {
          this.setState({
            ...this.state,
            errorOccurred: false,
            errorMessage: '',
          });
        } else {
          this.setState({
            ...this.state,
            errorOccurred: true,
            errorMessage: 'Error Occurred',
          });
        }
      });
  }

  render() {
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    }

    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
          <Button
            style={{ float: 'right' }}
            type="primary"
            onClick={(e: any) => {
              this.handleEditClick(e);
            }}
          >
            <i className="fas fa-edit" />
          </Button>
          <div>
            <div>
              <h3>Description</h3>
              <p>{String(this.state.model!.description)}</p>
            </div>
            <div>
              <h3>Jwt Key</h3>
              <p>{String(this.state.model!.jwtKey)}</p>
            </div>
            <div>
              <h3>Last Ip Address</h3>
              <p>{String(this.state.model!.lastIpAddress)}</p>
            </div>
            <div>
              <h3>Machine Guid</h3>
              <p>{String(this.state.model!.machineGuid)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Links</h3>
            <LinkTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Machines +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Links
              }
            />
          </div>
        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedMachineDetailComponent = Form.create({
  name: 'Machine Detail',
})(MachineDetailComponent);


/*<Codenesium>
    <Hash>16f88ccac3d8103cde2b0b7c167bcc7e</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/