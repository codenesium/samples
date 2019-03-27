import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerMapper from './officerMapper';
import OfficerViewModel from './officerViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { NoteTableComponent } from '../shared/noteTable';
import { OfficerCapabilitiesTableComponent } from '../shared/officerCapabilitiesTable';
import { UnitOfficerTableComponent } from '../shared/unitOfficerTable';
import { VehicleOfficerTableComponent } from '../shared/vehicleOfficerTable';

interface OfficerDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerDetailComponentState {
  model?: OfficerViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class OfficerDetailComponent extends React.Component<
  OfficerDetailComponentProps,
  OfficerDetailComponentState
> {
  state = {
    model: new OfficerViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Officers + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.OfficerClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Officers +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new OfficerMapper();

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
              <h3>Badge</h3>
              <p>{String(this.state.model!.badge)}</p>
            </div>
            <div>
              <h3>Email</h3>
              <p>{String(this.state.model!.email)}</p>
            </div>
            <div>
              <h3>First Name</h3>
              <p>{String(this.state.model!.firstName)}</p>
            </div>
            <div>
              <h3>Last Name</h3>
              <p>{String(this.state.model!.lastName)}</p>
            </div>
            <div>
              <h3>Password</h3>
              <p>{String(this.state.model!.password)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>Notes</h3>
            <NoteTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Officers +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.Notes
              }
            />
          </div>
          <div>
            <h3>OfficerCapabilities</h3>
            <OfficerCapabilitiesTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Officers +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.OfficerCapabilities
              }
            />
          </div>
          <div>
            <h3>UnitOfficers</h3>
            <UnitOfficerTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Officers +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.UnitOfficers
              }
            />
          </div>
          <div>
            <h3>VehicleOfficers</h3>
            <VehicleOfficerTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Officers +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.VehicleOfficers
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

export const WrappedOfficerDetailComponent = Form.create({
  name: 'Officer Detail',
})(OfficerDetailComponent);


/*<Codenesium>
    <Hash>c9837bb93e60995040207342fb7d16e3</Hash>
</Codenesium>*/