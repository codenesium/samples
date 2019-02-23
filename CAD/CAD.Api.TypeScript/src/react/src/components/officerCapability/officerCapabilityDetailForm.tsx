import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerCapabilityMapper from './officerCapabilityMapper';
import OfficerCapabilityViewModel from './officerCapabilityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { OfficerRefCapabilityTableComponent } from '../shared/officerRefCapabilityTable';

interface OfficerCapabilityDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerCapabilityDetailComponentState {
  model?: OfficerCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class OfficerCapabilityDetailComponent extends React.Component<
  OfficerCapabilityDetailComponentProps,
  OfficerCapabilityDetailComponentState
> {
  state = {
    model: new OfficerCapabilityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.OfficerCapabilities + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.OfficerCapabilities +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.OfficerCapabilityClientResponseModel;

          console.log(response);

          let mapper = new OfficerCapabilityMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
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
              <h3>name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>OfficerRefCapabilities</h3>
            <OfficerRefCapabilityTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.OfficerCapabilities +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.OfficerRefCapabilities
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

export const WrappedOfficerCapabilityDetailComponent = Form.create({
  name: 'OfficerCapability Detail',
})(OfficerCapabilityDetailComponent);


/*<Codenesium>
    <Hash>499d6fe4dc52071aa8938adfd6b0d2fa</Hash>
</Codenesium>*/