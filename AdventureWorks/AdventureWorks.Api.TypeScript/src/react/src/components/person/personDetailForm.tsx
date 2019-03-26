import React, { Component, FormEvent } from 'react';
import axios, { AxiosError, AxiosResponse } from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import PersonMapper from './personMapper';
import PersonViewModel from './personViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import * as GlobalUtilities from '../../lib/globalUtilities';
import { BusinessEntityContactTableComponent } from '../shared/businessEntityContactTable';
import { EmailAddressTableComponent } from '../shared/emailAddressTable';
import { PasswordTableComponent } from '../shared/passwordTable';
import { PersonPhoneTableComponent } from '../shared/personPhoneTable';

interface PersonDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface PersonDetailComponentState {
  model?: PersonViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class PersonDetailComponent extends React.Component<
  PersonDetailComponentProps,
  PersonDetailComponentState
> {
  state = {
    model: new PersonViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: '',
  };

  handleEditClick(e: any) {
    this.props.history.push(
      ClientRoutes.People + '/edit/' + this.state.model!.businessEntityID
    );
  }

  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get<Api.PersonClientResponseModel>(
        Constants.ApiEndpoint +
          ApiRoutes.People +
          '/' +
          this.props.match.params.id,
        {
          headers: GlobalUtilities.defaultHeaders(),
        }
      )
      .then(response => {
        GlobalUtilities.logInfo(response);

        let mapper = new PersonMapper();

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
              <h3>Additional Contact Info</h3>
              <p>{String(this.state.model!.additionalContactInfo)}</p>
            </div>
            <div>
              <h3>Demographics</h3>
              <p>{String(this.state.model!.demographic)}</p>
            </div>
            <div>
              <h3>Email Promotion</h3>
              <p>{String(this.state.model!.emailPromotion)}</p>
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
              <h3>Middle Name</h3>
              <p>{String(this.state.model!.middleName)}</p>
            </div>
            <div>
              <h3>Modified Date</h3>
              <p>{String(this.state.model!.modifiedDate)}</p>
            </div>
            <div>
              <h3>Name Style</h3>
              <p>{String(this.state.model!.nameStyle)}</p>
            </div>
            <div>
              <h3>Person Type</h3>
              <p>{String(this.state.model!.personType)}</p>
            </div>
            <div>
              <h3>Rowguid</h3>
              <p>{String(this.state.model!.rowguid)}</p>
            </div>
            <div>
              <h3>Suffix</h3>
              <p>{String(this.state.model!.suffix)}</p>
            </div>
            <div>
              <h3>Title</h3>
              <p>{String(this.state.model!.title)}</p>
            </div>
          </div>
          {message}
          <div>
            <h3>BusinessEntityContacts</h3>
            <BusinessEntityContactTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.People +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.BusinessEntityContacts
              }
            />
          </div>
          <div>
            <h3>EmailAddresses</h3>
            <EmailAddressTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.People +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.EmailAddresses
              }
            />
          </div>
          <div>
            <h3>Passwords</h3>
            <PasswordTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.People +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.Passwords
              }
            />
          </div>
          <div>
            <h3>PersonPhones</h3>
            <PersonPhoneTableComponent
              history={this.props.history}
              match={this.props.match}
              apiRoute={
                Constants.ApiEndpoint +
                ApiRoutes.People +
                '/' +
                this.state.model!.businessEntityID +
                '/' +
                ApiRoutes.PersonPhones
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

export const WrappedPersonDetailComponent = Form.create({
  name: 'Person Detail',
})(PersonDetailComponent);


/*<Codenesium>
    <Hash>527d5d8e993e52d68e169114817dc654</Hash>
</Codenesium>*/