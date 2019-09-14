import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UnitMapper from './unitMapper';
import UnitViewModel from './unitViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { CallAssignmentTableComponent } from '../shared/callAssignmentTable';
import { UnitOfficerTableComponent } from '../shared/unitOfficerTable';

interface UnitDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UnitDetailComponentState {
  model?: UnitViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UnitDetailComponent extends React.Component<
  UnitDetailComponentProps,
  UnitDetailComponentState
> {
  state = {
    model: new UnitViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.Units + '/edit/' + this.state.model!.id
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.UnitClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.Units +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new UnitMapper();

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
              <h3>Call Sign</h3>
              <p>{String(this.state.model!.callSign)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>CallAssignments</h3>
            <CallAssignmentTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.Units +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.CallAssignments
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
                ApiRoutes.Units +
                '/' +
                this.state.model!.id +
                '/' +
                ApiRoutes.UnitOfficers
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

export const WrappedUnitDetailComponent = Form.create({ name: 'Unit Detail' })(
  UnitDetailComponent
);


/*<Codenesium>
    <Hash>a7a9745cab443044575edf5ff72ef619</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/