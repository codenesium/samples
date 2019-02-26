import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OrganizationMapper from './organizationMapper';
import OrganizationViewModel from './organizationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import { TeamTableComponent } from '../shared/teamTable';

interface OrganizationDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OrganizationDetailComponentState {
  model?: OrganizationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class OrganizationDetailComponent extends React.Component<
  OrganizationDetailComponentProps,
  OrganizationDetailComponentState
> {
  state = {
    model: new OrganizationViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Organizations + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Organizations +
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
          let response = resp.data as Api.OrganizationClientResponseModel;

          console.log(response);

          let mapper = new OrganizationMapper();

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
              <h3>Id</h3>
              <p>{String(this.state.model!.id)}</p>
            </div>
            <div>
              <h3>Name</h3>
              <p>{String(this.state.model!.name)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Teams</h3>
            <TeamTableComponent
              id={this.state.model!.id}
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Organizations +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Teams
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

export const WrappedOrganizationDetailComponent = Form.create({
  name: 'Organization Detail',
})(OrganizationDetailComponent);


/*<Codenesium>
    <Hash>42f06e276cb3af15bc101a889540be06</Hash>
</Codenesium>*/